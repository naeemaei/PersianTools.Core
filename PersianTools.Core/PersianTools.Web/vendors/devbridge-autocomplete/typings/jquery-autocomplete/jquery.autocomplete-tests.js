///<reference path="../jquery/jquery.d.ts" />
///<reference path="../jquery-autocomplete/jquery.autocomplete.d.ts" />
// ----------------------------------------------------------------------------------------
// --------------------------------- WEBSITE EXAMPLE --------------------------------------
// ---------- https://www.devbridge.com/sourcery/components/jquery-autocomplete/ ----------
// ----------------------------------------------------------------------------------------
var input = $('#autocomplete');
var options = {};
input.autocomplete('disable');
input.autocomplete('setOptions', options);
input.autocomplete().disable();
input.autocomplete().setOptions(options);
// Ajax lookup:
input.autocomplete({
    serviceUrl: '/autocomplete/countries',
    onSelect: function (suggestion) {
        alert('You selected: ' + suggestion.value + ', ' + suggestion.data);
    }
});
// Local lookup (no ajax):
var countries = [
    { value: 'Andorra', data: 'AD' },
    // ...
    { value: 'Zimbabwe', data: 'ZZ' }
];
input.autocomplete({
    lookup: countries,
    onSelect: function (suggestion) {
        alert('You selected: ' + suggestion.value + ', ' + suggestion.data);
    }
});
// Non standard query/results
input.autocomplete({
    paramName: 'searchString',
    transformResult: function (response, originalQuery) {
        return {
            suggestions: $.map(response.myData, function (dataItem) {
                return { value: dataItem.valueField, data: dataItem.dataField };
            })
        };
    }
});
// ----------------------------------------------------------------------------------------
// ------------------------------ TEST INSTANCE METHODS -----------------------------------
// ----------------------------------------------------------------------------------------
input.autocomplete().setOptions(options);
input.autocomplete().clear();
input.autocomplete().clearCache();
input.autocomplete().disable();
input.autocomplete().enable();
input.autocomplete().hide();
input.autocomplete().dispose();
// ----------------------------------------------------------------------------------------
// ------------------------------ TEST DEFAULT OPTIONS ------------------------------------
// ----------------------------------------------------------------------------------------
input.autocomplete({
    //----------------o AJAX SETTINGS
    serviceUrl: '/autocomplete/countries',
    type: 'GET',
    dataType: 'text',
    paramName: 'query',
    params: {},
    deferRequestBy: 0,
    ajaxSettings: {},
    //----------------o CONFIG SETTINGS
    noCache: false,
    delimiter: "-",
    onSearchStart: function (query) {
        console.log("query: ", query);
    },
    onSearchComplete: function (query, suggestions) {
        console.log("query: ", query);
        console.log("suggestions: ", suggestions);
    },
    onSearchError: function (query, jqXHR, textStatus, errorThrown) {
        console.log("query: ", query);
        console.log("jqXHR: ", jqXHR);
        console.log("textStatus: ", textStatus);
        console.log("errorThrown: ", errorThrown);
    },
    transformResult: function (response, originalQuery) {
        return {
            suggestions: [
                { value: 'Andorra', data: 'AD' },
                // ...
                { value: 'Zimbabwe', data: 'ZZ' }
            ]
        };
    },
    onSelect: function (suggestion) {
        console.log("suggestions: ", suggestion);
    },
    minChars: 1,
    lookupLimit: 1,
    lookup: [
        { value: 'Andorra', data: 'AD' },
        // ...
        { value: 'Zimbabwe', data: 'ZZ' }
    ],
    lookupFilter: function (suggestion, query, queryLowercase) {
        return query !== "query";
    },
    triggerSelectOnValidInput: true,
    preventBadQueries: true,
    autoSelectFirst: false,
    onHide: function (container) {
        console.log("container: ", container);
    },
    //----------------o PRESENTATION SETTINGS
    beforeRender: function (container) {
        console.log("container: ", container);
    },
    formatResult: function (suggestion, currentValue) {
        return currentValue;
    },
    groupBy: "category",
    maxHeight: 300,
    width: "auto",
    zIndex: 9999,
    appendTo: document.body,
    forceFixPosition: false,
    orientation: "bottom",
    preserveInput: false,
    showNoSuggestionNotice: false,
    noSuggestionNotice: "No results",
    onInvalidateSelection: function () {
        console.log("onInvalidateSelection");
    },
    tabDisabled: false
});
//# sourceMappingURL=jquery.autocomplete-tests.js.map