$(document).ready(function () {
    console.log("!!!!!!!!!!!")
    $('#feedbackForm').on('submit', function (event) {
        event.preventDefault();

        var feedback = {
            name: $('#Name').val(),
            comment: $('#Comment').val()
        };

        $.ajax({
            url: '/Feedback/Submit',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(feedback),
            success: function (response) {
                var feedbackItem = '<div class="feedback_item">' +
                    '<p><strong>' + response.name + '</strong> (' + new Date(response.date).toLocaleString() + ')</p>' +
                    '<p>' + response.comment + '</p>' +
                    '</div>';
                $('#feedbackList').append(feedbackItem);
                $('#feedbackForm')[0].reset();
            },
            error: function (xhr, status, error) {
                alert('An error occurred: ' + error);
            }
        });
    });
});
