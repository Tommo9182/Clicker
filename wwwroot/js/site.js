function timeButton(seconds, button) {
    var timeButtons = document.getElementById("time-buttons").children;
    const incrementButton = document.getElementById("increment-button");

    document.getElementById("select-your-time").style.visibility = "hidden";

    time = seconds;
    timeRemaining = seconds;

    button.style.backgroundColor = "green";
    for (let i = 0; i < timeButtons.length; i++) {
        if (timeButtons[i] != button) {
            timeButtons[i].style.backgroundColor = "#efefef";
        }
        timeButtons[i].disabled = true;
    }
    incrementButton.style.visibility = "visible";
}

function leaderboardTimeButton(seconds, button) {
    var timeButtons = document.getElementById("leaderboard-time-buttons").children;

    button.style.backgroundColor = "green";
    for (let i = 0; i < timeButtons.length; i++) {
        if (timeButtons[i] != button) {
            timeButtons[i].style.backgroundColor = "#efefef";
        }
    }
    location.href(String.Format("Leaderboard/time={seconds}"));
}

function deleteScore(Id) {
    $.ajax({
        type: "DELETE",
        url: "/Score/Delete",
        data: {
            Id: Id
        },
        success: function (response) {
            console.log("Score deleted successfully");
            location.reload();
        },
        error: function (error) {
            console.error("Error deleting score: ", error);
        }
    })
}

function deleteAllScores() {
    $.ajax({
        type: "DELETE",
        url: "/Score/DeleteAll",
        success: function (response) {
            console.log("Score deleted successfully");
            location.reload();
        },
        error: function (error) {
            console.error("Error deleting score: ", error);
        }
    })
}
