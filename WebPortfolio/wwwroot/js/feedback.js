// Submitted feedback update
$(document).ready(function () {
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

// Delete function
$(document).on("click", ".delete_button", function () {
    const feedbackId = $(this).data("id");

    if (confirm("Are you sure you want to delete this feedback?")) {
        $.ajax({
            url: `/Feedback/Delete/${feedbackId}`,
            type: "DELETE",
            success: function (response) {
                alert(response.message);
                $(`button[data-id="${feedbackId}"]`).closest(".feedback_item").remove();
            },
            error: function (xhr) {
                alert("An error occurred while deleting feedback.");
            }
        });
    }
});