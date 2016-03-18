(function () {
    'use strict';
    $(document).ready(function () {
        var MAX_VOTE = 10,
            MIN_VOTE = 0;

        $("div[data-action='up']").on('click', function () {
            changeVote(1);
        });

        $("div[data-action='down']").on('click', function () {
            changeVote(-1);
        });

        $('#btn-movie-vote').on('click', function () {
            var $vote = $('#movie-vote-value');
            var movieId = $vote.data().id;
            var value = $vote.text() | 0;
            voteClick(movieId, value);
        });

        function changeVote(value) {
            var $vote = $('#movie-vote-value');
            var totalVotes = $vote.text() | 0;

            if (value > 0) {
                if ((totalVotes + value) <= MAX_VOTE) {
                    $vote.html(totalVotes + value);
                }
            }
            else if (value < 0) {
                if ((totalVotes + value) > MIN_VOTE) {
                    $vote.html(totalVotes + value);
                }
            }
        }

        function voteClick(id, vote) {
            $.post("/Users/Ratings/AddRating", { movieId: id, ratingValue: vote },
                function (data) {
                    var rating = data.Count;
                    var $vote = $('#vote-value');
                    $vote.empty();
                    $vote.append('<span>Rating: </span>');

                    for (var i = 0; i < rating; i += 1) {
                        $('<span />')
                            .addClass('glyphicon glyphicon-star')
                            .appendTo($vote);
                    }
                });
        }
    })
})();