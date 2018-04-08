<!-- Footer -->
<footer class="footer text-right">
    <div class="container">
        <div class="row">
            <div class="col-xs-12">
                2014 - <span id="date"></span> © Léo HUBERT.
            </div>
        </div>
    </div>
</footer>
<script src="/assets/js/jquery.min.js"></script>
<!-- End Footer -->
<script type="text/javascript">
    var d = new Date();
    var n = d.getFullYear();
    document.getElementById("date").innerHTML = n;

    $(function() {
        setInterval(function () {
            window.location = "/lock";
        }, 1800000);
    });
</script>

