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
});