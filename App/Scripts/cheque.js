$(document).ready(function() {

    function viewModel() {
        var vm = this;
        vm.name = ko.observable('');
        vm.date = ko.observable('');
        vm.amount = ko.observable('');

        vm.chqAmount = ko.observable('');

        vm.showAmt = ko.computed(function () {
            return vm.amount();
        }, vm);

        vm.showName = ko.computed(function() {
            return vm.name();
        }, vm);
        this.showDate = ko.computed(function() {
            return vm.date();
        }, vm);
        vm.showAmount = ko.computed(function() {
            var amt = vm.amount();

            if (amt > 999999999) {
                vm.amount(999999999);
                alert('Maximum 999 million is allowed in the cheque amount.');
                return false;
            }
            else if (amt < 0 || isNaN(amt)) {
                vm.amount(0);
                return false;
            }
            else if (amt.toString().substr(0, 1) === '0' && amt.toString().length > 1) {
                vm.amount(0);
                return false;
            }

            if (amt !== '') {

                $.ajax({
                    dataType: "json",
                    url: '/api/cheque/' + amt + '/amount',
                    data: null,
                    success: function(response) {
                        vm.chqAmount(response);
                    },
                    error: function (err, code) {
                        vm.chqAmount('');
                    }
                });
            }
        }, vm);
    }

    ko.applyBindings(new viewModel());

    $("#date").datepicker({ dateFormat: 'dd MM yy' });
});