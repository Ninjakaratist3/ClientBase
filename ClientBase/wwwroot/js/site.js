$(function () {
    $('.client-delete').click(async function () {
        var clientId = $(this).siblings('.client-id').val();
        var $parent = $(this).parent('div');

        await fetch('client/delete/' + clientId, { method: 'POST' })
            .then(
                function (response) {
                    $parent.remove();
                } 
            )
            .catch(function (err) {
                console.log('Fetch Error :-S', err);
            });
    });
    $('.city-delete').click(async function () {
        var citytId = $(this).siblings('.city-id').val();
        var $parent = $(this).parent('div');

        await fetch('city/delete/' + cityId, { method: 'POST' })
            .then(
                function (response) {
                    $parent.remove();
                }
            )
            .catch(function (err) {
                console.log('Fetch Error :-S', err);
            });
    });
    $('.country-delete').click(async function () {
        var countryId = $(this).siblings('.country-id').val();
        var $parent = $(this).parent('div');

        await fetch('country/delete/' + countryId, { method: 'POST' })
            .then(
                function (response) {
                    $parent.remove();
                }
            )
            .catch(function (err) {
                console.log('Fetch Error :-S', err);
            });
    });
    $('.property-type-delete').click(async function () {
        var propertyTypeId = $(this).siblings('.property-type-id').val();
        var $parent = $(this).parent('div');

        await fetch('property-type/delete/' + propertyTypeId, { method: 'POST' })
            .then(
                function (response) {
                    $parent.remove();
                }
            )
            .catch(function (err) {
                console.log('Fetch Error :-S', err);
            });
    });
    $('.industry-delete').click(async function () {
        var industryId = $(this).siblings('.industry-id').val();
        var $parent = $(this).parent('div');

        await fetch('industry/delete/' + industryId, { method: 'POST' })
            .then(
                function (response) {
                    $parent.remove();
                }
            )
            .catch(function (err) {
                console.log('Fetch Error :-S', err);
            });
    });
});