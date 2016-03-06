(function () {
    'use strict';

    var $actorsContainer = $('#add-actor-container');
    var $btnAddActor = $('#btn-add-actor');
    var $movieImagesContainer = $('#add-images-container');
    var $btnAddMovieImage = $('#btn-add-image');

    $btnAddActor.on('click', function (ev) {
        var actorsCount = $actorsContainer.children('input').length;
        var $inputText = $('<input/>').attr({
            name: 'Actors[' + actorsCount + ']',
            type: 'text',
            required: 'required',
            'class': 'form-control'
        });

        $actorsContainer
            .append('<br/>')
            .append($inputText);
    });

    $btnAddMovieImage.on('click', function (ev) {
        var movieImagesCount = $movieImagesContainer.children('input').length;
        var $inputFile = $('<input/>').attr({
            name: 'movieImages',
            type: 'file',
            required: 'required',
            'class': 'form-control'
        });

        $movieImagesContainer
            .append('<br/>')
            .append($inputFile);
    });

})();