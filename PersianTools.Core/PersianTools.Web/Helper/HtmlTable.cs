using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace PersianTools.Web.Helper
{
    #region TableColumn
    public interface ITableColumnInternal<TModel> where TModel : class
    {
        string ColumnTitle
        {
            get;
            set;
        }
        string Evaluate(TModel model);
    }

    /// <summary>    
    /// Properties and methods used by the consumer to configure the TableColumn.    
    /// </summary>    
    public interface ITableColumn
    {
        ITableColumn Title(string title);
    }

    /// <summary>    
    /// Represents a column in a table.    
    /// </summary>    
    /// <typeparam name="TModel">Class that is rendered in a table.</typeparam>    
    /// <typeparam name="TProperty">Class property that is rendered in the column.</typeparam>    
    public class TableColumn<TModel,
    TProperty> : ITableColumn,
    ITableColumnInternal<TModel> where TModel : class
    {
        /// <summary>    
        /// Column title to display in the table.    
        /// </summary>    
        public string ColumnTitle
        {
            get;
            set;
        }

        /// <summary>    
        /// Compiled lambda expression to get the property value from a model object.    
        /// </summary>    
        public Func<TModel, TProperty> CompiledExpression
        {
            get;
            set;
        }

        /// <summary>    
        /// Constructor.    
        /// </summary>    
        /// <param name="expression">Lambda expression identifying a property to be rendered.</param>    
        public TableColumn(Expression<Func<TModel, TProperty>> expression)
        {
            string propertyName = (expression.Body as MemberExpression).Member.Name;
            this.ColumnTitle = Regex.Replace(propertyName, "([a-z])([A-Z])", "$1 $2");
            this.CompiledExpression = expression.Compile();
        }

        /// <summary>    
        /// Set the title for the column.    
        /// </summary>    
        /// <param name="title">Title for the column.</param>    
        /// <returns>Instance of a TableColumn.</returns>    
        public ITableColumn Title(string title)
        {
            this.ColumnTitle = title;
            return this;
        }

        /// <summary>    
        /// Get the property value from a model object.    
        /// </summary>    
        /// <param name="model">Model to get the property value from.</param>    
        /// <returns>Property value from the model.</returns>    
        public string Evaluate(TModel model)
        {
            var result = this.CompiledExpression(model);
            return result == null ? string.Empty : result.ToString();
        }
    }

#endregion TableColumn  

    #region ColumnBuilder  

    /// <summary>    
    /// Create instances of TableColumns.    
    /// </summary>    
    /// <typeparam name="TModel">Type of model to render in the table.</typeparam>    
    public class ColumnBuilder<TModel> where TModel : class
    {
        public TableBuilder<TModel> TableBuilder
        {
            get;
            set;
        }

        /// <summary>    
        /// Constructor.    
        /// </summary>    
        /// <param name="tableBuilder">Instance of a TableBuilder.</param>    
        public ColumnBuilder(TableBuilder<TModel> tableBuilder)
        {
            TableBuilder = tableBuilder;
        }

        /// <summary>    
        /// Add lambda expressions to the TableBuilder.    
        /// </summary>    
        /// <typeparam name="TProperty">Class property that is rendered in the column.</typeparam>    
        /// <param name="expression">Lambda expression identifying a property to be rendered.</param>    
        /// <returns>An instance of TableColumn.</returns>    
        public ITableColumn Expression<TProperty>(Expression<Func<TModel, TProperty>> expression)
        {
            return TableBuilder.AddColumn(expression);
        }
    }

    #endregion ColumnBuilder  

    #region TableBuilder  

    /// <summary>    
    /// Properties and methods used by the consumer to configure the TableBuilder.    
    /// </summary>    
    public interface ITableBuilder<TModel> where TModel : class
    {
        TableBuilder<TModel> DataSource(IEnumerable<TModel> dataSource);
        TableBuilder<TModel> Columns(Action<ColumnBuilder<TModel>> columnBuilder);
    }

    /// <summary>    
    /// Build a table based on an enumerable list of model objects.    
    /// </summary>    
    /// <typeparam name="TModel">Type of model to render in the table.</typeparam>    
    public class TableBuilder<TModel> : ITableBuilder<TModel> where TModel : class
    {
        private HtmlHelper HtmlHelper
        {
            get;
            set;
        }
        private IEnumerable<TModel> Data
        {
            get;
            set;
        }

        /// <summary>    
        /// Default constructor.    
        /// </summary>    
        private TableBuilder() { }

        /// <summary>    
        /// Constructor.    
        /// </summary>    
        internal TableBuilder(HtmlHelper helper)
        {
            this.HtmlHelper = helper;

            this.TableColumns = new List<ITableColumnInternal<TModel>>();
        }

        /// <summary>    
        /// Set the enumerable list of model objects.    
        /// </summary>    
        /// <param name="dataSource">Enumerable list of model objects.</param>    
        /// <returns>Reference to the TableBuilder object.</returns>    
        public TableBuilder<TModel> DataSource(IEnumerable<TModel> dataSource)
        {
            this.Data = dataSource;
            return this;
        }

        /// <summary>    
        /// List of table columns to be rendered in the table.    
        /// </summary>    
        internal IList<ITableColumnInternal<TModel>> TableColumns
        {
            get;
            set;
        }

        /// <summary>    
        /// Add an lambda expression as a TableColumn.    
        /// </summary>    
        /// <typeparam name="TProperty">Model class property to be added as a column.</typeparam>    
        /// <param name="expression">Lambda expression identifying a property to be rendered.</param>    
        /// <returns>An instance of TableColumn.</returns>    
        internal ITableColumn AddColumn<TProperty>(Expression<Func<TModel, TProperty>> expression)
        {
            TableColumn<TModel, TProperty> column = new TableColumn<TModel, TProperty>(expression);
            this.TableColumns.Add(column);
            return column;
        }

        /// <summary>    
        /// Create an instance of the ColumnBuilder to add columns to the table.    
        /// </summary>    
        /// <param name="columnBuilder">Delegate to create an instance of ColumnBuilder.</param>    
        /// <returns>An instance of TableBuilder.</returns>    
        public TableBuilder<TModel> Columns(Action<ColumnBuilder<TModel>> columnBuilder)
        {
            ColumnBuilder<TModel> builder = new ColumnBuilder<TModel>(this);
            columnBuilder(builder);
            return this;
        }

        /// <summary>    
        /// Convert the TableBuilder to HTML.    
        /// </summary>    
        public MvcHtmlString ToHtml(string id, string CssClass, string EditPath, string DeletePath)
        {

            var table = new TagBuilder("table");
            table.GenerateId(id);
            table.AddCssClass(CssClass);

            //For Declaration Of All Require Tag...!!!    
            TagBuilder thead = new TagBuilder("thead");
            TagBuilder tr = new TagBuilder("tr");
            TagBuilder td = null;
            //TagBuilder th = new TagBuilder("th");    
            TagBuilder th = null;
            TagBuilder tbody = new TagBuilder("tbody");

            //Inner html Of Table...!!!    
            StringBuilder sb = new StringBuilder();
            //Add Headers...!!!    
            int i = 0;
            foreach (ITableColumnInternal<TModel> tc in this.TableColumns)
            {
                th = new TagBuilder("th");
                if (i == 0)
                {
                    th.InnerHtml = tc.ColumnTitle;
                    th.MergeAttribute("style", "display:none;");
                }
                else
                {
                    th.InnerHtml = tc.ColumnTitle;

                }
                i++;
                tr.InnerHtml += th.ToString();
            }
            th.InnerHtml = "اعمال";
            tr.InnerHtml += th.ToString();
            thead.InnerHtml = tr.ToString();
            sb.Append(thead.ToString());

            //For Row Data and Coloumn...!!!    
            if (this.Data != null)
            {
                //var data in RowDetail    
                int row = 0;
                foreach (TModel model in this.Data)
                {
                    if (model != null)
                    {
                        tr.InnerHtml = "";
                        //var header in Headernames    
                        int j = 0;
                        string ID = "";
                        foreach (ITableColumnInternal<TModel> tc in this.TableColumns)
                        {
                            td = new TagBuilder("td");
                            if (j == 0)
                            {
                                ID = tc.Evaluate(model);
                                td.InnerHtml = tc.Evaluate(model);
                                td.MergeAttribute("style", "display:none;");
                            }
                            else
                            {
                                td.InnerHtml = tc.Evaluate(model);
                            }
                            tr.InnerHtml += td.ToString();
                            j++;
                        }
                        var editPath = EditPath == string.Empty ? "#" : EditPath + ID;
                        var deletePath = DeletePath == string.Empty ? "#" : DeletePath + ID;
                        td.InnerHtml = "<a href='" + editPath + "' class='btn btn-primary'>ویرایش</a> <a href='" + deletePath + "'  class='btn btn-danger'>حذف</a>";
                        tr.InnerHtml += td.ToString();
                        tbody.InnerHtml += tr.ToString();
                        row++;
                    }
                }

                sb.Append(tbody.ToString());
                table.InnerHtml = sb.ToString();
            }
            return new MvcHtmlString(table.ToString());

        }
    }

    #endregion TableBuilder  

    #region MvcHtmlTableExtensions  

    public static class MvcHtmlTableExtensions
    {
        /// <summary>    
        /// Return an instance of a TableBuilder.    
        /// </summary>    
        /// <typeparam name="TModel">Type of model to render in the table.</typeparam>    
        /// <returns>Instance of a TableBuilder.</returns>    
        public static ITableBuilder<TModel> TableFor<TModel>(this HtmlHelper helper) where TModel :  class
        {
            return new TableBuilder<TModel>(helper);
        }
    }

    #endregion MvcHtmlTableExtensions  
}