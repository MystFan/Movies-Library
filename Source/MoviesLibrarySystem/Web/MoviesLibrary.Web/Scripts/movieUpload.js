(function () {
    'use strict';

    var $actorsContainer = $('#add-actor-container');
    var $btnAddActor = $('#btn-add-actor');
    var $movieImagesContainer = $('#add-images-container');
    var $btnAddMovieImage = $('#btn-add-image');
    var $directorsContainer = $('#add-director-container');
    var $btnAddDirector = $('#btn-add-director');

    $btnAddActor.on('click', function (ev) {
        appendInput('Actors', $actorsContainer);
    });

    $btnAddDirector.on('click', function (ev) {
        appendInput('Directors', $directorsContainer);
    });

    $btnAddMovieImage.on('click', function (ev) {
        var movieImagesCount = $movieImagesContainer.children('input').length;
        var $inputFile = $('<input/>').attr({
            name: 'movieImages',
            type: 'file',
            required: 'required',
            'class': 'form-control'
        });

        var radioCount = $movieImagesContainer.children('input[type="radio"]').length;
        var $inputRadio = $('<input/>').attr({
            name: 'PosterIndex',
            value: radioCount,
            type: 'radio'
        });

        $movieImagesContainer
            .append('<br/>')
            .append($inputRadio)
            .append($inputFile);
    });

    function appendInput(propName, $container) {
        var elementsCount = $container.children('input').length;
        var $inputText = $('<input/>').attr({
            name: propName + '[' + elementsCount + ']',
            type: 'text',
            required: 'required',
            'class': 'form-control'
        });

        $container
            .append('<br/>')
            .append($inputText);
    }
})();