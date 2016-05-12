(function () {
    'use strict';

    var $movieImagesContainer = $('#add-images-container');
    var $btnAddImage = $('#btn-add-image');

    $btnAddImage.on('click', function (ev) {
        var movieImagesCount = $movieImagesContainer.children('input').length;
        var $inputFile = $('<input/>').attr({
            name: 'images',
            type: 'file',
            required: 'required',
            'class': 'form-control'
        });

        $movieImagesContainer
            .append('<br/>')
            .append($inputFile);
    });

    function appendInput(propName, $container) {
        var elementsCount = $container.children('input').length;
        var $inputText = $('<input/>').attr({
            name: propName + '[' + elementsCount + ']',
            type: 'text',
            'class': 'form-control'
        });

        $container
            .append('<br/>')
            .append($inputText);
    }
})();