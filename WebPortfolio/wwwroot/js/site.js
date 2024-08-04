$(document).ready(function () {
    $('#feedbackForm').on('submit', function (event) {
        event.preventDefault(); // Prevent the default form submission

        var feedback = {
            name: $('#name').val(),
            comment: $('#comment').val()
        };

        $.ajax({
            url: '/Feedback/Create',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(feedback),
            success: function (response) {
                var feedbackItem = '<div class="feedback-item">' +
                    '<p><strong>' + response.name + '</strong> (' + new Date(response.date).toLocaleString() + ')</p>' +
                    '<p>' + response.comment + '</p>' +
                    '</div>';
                $('#feedbackList').prepend(feedbackItem);
                $('#feedbackForm')[0].reset();
            },
            error: function (xhr, status, error) {
                alert('An error occurred: ' + error);
            }
        });
    });
});