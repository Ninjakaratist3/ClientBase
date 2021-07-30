$(function () {
    $('.client-delete').click(async function () {
        var clientId = $(this).parent('td').siblings('.client-id').text();
        var $parent = $(this).parents('tr');

        await fetch('/client/delete/' + clientId, { method: 'POST' })
            .then(
                function (response) {
                    $parent.remove();
                }
            );
    });
    $('.city-delete').click(async function () {
        var cityId = $(this).parent('td').siblings('.city-id').text();
        var $parent = $(this).parents('tr');

        await fetch('/city/delete/' + cityId, { method: 'POST' })
            .then(
                function (response) {
                    $parent.remove();
                }
            );
    });
    $('.country-delete').click(async function () {
        var countryId = $(this).parent('td').siblings('.country-id').text();
        var $parent = $(this).parents('tr');

        await fetch('/country/delete/' + countryId, { method: 'POST' })
            .then(
                function (response) {
                    $parent.remove();
                }
            );
    });
    $('.property-type-delete').click(async function () {
        var propertyTypeId = $(this).parent('td').siblings('.property-type-id').text();
        var $parent = $(this).parents('tr');

        await fetch('/property-type/delete/' + propertyTypeId, { method: 'POST' })
            .then(
                function (response) {
                    $parent.remove();
                }
            );
    });
    $('.industry-delete').click(async function () {
        var industryId = $(this).parent('td').siblings('.industry-id').text();
        var $parent = $(this).parents('tr');

        await fetch('/industry/delete/' + industryId, { method: 'POST' })
            .then(
                function (response) {
                    $parent.remove();
                }
            );
    });
    $('.client-name-search').keyup(async function () {
        var searchQuery = $(this).val();

        $('.clients-list').children('tr').each(function (i, element) {
            DefinitionListItemVisibility(element, searchQuery);
        });
    });
    $('.city-name-search').keyup(async function () {
        var searchQuery = $(this).val();

        $('.cities-list').children('tr').each(function (i, element) {
            DefinitionListItemVisibility(element, searchQuery);
        });
    });
    $('.country-name-search').keyup(async function () {
        var searchQuery = $(this).val();

        $('.countries-list').children('tr').each(function (i, element) {
            DefinitionListItemVisibility(element, searchQuery);
        });
    });
    $('.property-type-name-search').keyup(async function () {
        var searchQuery = $(this).val();

        $('.property-types-list').children('tr').each(function (i, element) {
            DefinitionListItemVisibility(element, searchQuery);
        });
    });
    $('.industry-name-search').keyup(async function () {
        var searchQuery = $(this).val();

        $('.industries-list').children('tr').each(function (i, element) {
            DefinitionListItemVisibility(element, searchQuery);
        });
    });

    function isEmptyOrSpaces(str) {
        return str === null || str.match(/^ *$/) !== null;
    }

    function DefinitionListItemVisibility(element, searchQuery) {
        if (searchQuery.length == 0 || isEmptyOrSpaces(searchQuery)) {
            element.style.visibility = "visible";
        }
        else if (!element.title.toLowerCase().startsWith(searchQuery.toLowerCase())) {
            element.style.visibility = "collapse";
        }
        else {
            element.style.visibility = "visible";
        }
    }
});