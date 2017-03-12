var tibox = tibox || {};

(function () {
    tibox.Index = {
        currentYear: function () {
            var today = new Date();
            return today.getFullYear();
        }
    };

    document.getElementById("date").innerHTML = tibox.Index.currentYear();
})();
