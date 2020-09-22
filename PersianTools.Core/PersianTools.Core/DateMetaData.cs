namespace PersianTools.Core
{
	public class DateMetaData
	{
		public string Id { get; set; }
		public string Description { get; set; }
		public CalenderType CalenderType { get; set; }
		public DateType DateType { get; set; }
		public bool IsHoliDay { get; set; }
		public string CalenderTypeDesc
		{
			get
			{
				return this.CalenderType.GetDescription();
			}
		}
		public string DateTypeDesc
		{
			get
			{
				return this.DateType.GetDescription();
			}
		}
	}
}
