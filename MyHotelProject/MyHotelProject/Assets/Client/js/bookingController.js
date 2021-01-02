var booking = {
    init: function () {
        booking.regEvents();
    },
    regEvents: function () {
        $(document).ready(function () {
            $('input.room-qty').change(function () {
                var listRoomtype = $('.room-qty');
                var bookingList = [];
                $.each(listRoomtype, function (i, item) {
                    bookingList.push({
                        Quantity: $(item).val(),
                        Roomtype: {
                            ID: $(item).data('id')
                        }
                    });
                });
                $.ajax({
                    url: '/Booking/UpdateQuantity',
                    data: { bookingModel: JSON.stringify(bookingList) },
                    dataType: 'json',
                    type: 'POST',
                    success: function (res) {
                        if (res.status == true) {
                            window.location.href = "/home";
                        }
                    }
                })
            })
        });
        $(document).ready(function () {
            $('input.adult-qty').change(function () {
                var listRoomtype = $('.adult-qty');
                var bookingList = [];
                $.each(listRoomtype, function (i, item) {
                    bookingList.push({
                        Adult: $(item).val(),
                        Roomtype: {
                            ID: $(item).data('id')
                        }
                    });
                });
                $.ajax({
                    url: '/Booking/UpdateAdult',
                    data: { bookingModel: JSON.stringify(bookingList) },
                    dataType: 'json',
                    type: 'POST',
                    success: function (res) {
                        if (res.status == true) {
                            window.location.href = "/home";
                        }
                    }
                })
            })
        });
        $(document).ready(function () {
            $('input.child-qty').change(function () {
                var listRoomtype = $('.child-qty');
                var bookingList = [];
                $.each(listRoomtype, function (i, item) {
                    bookingList.push({
                        Children: $(item).val(),
                        Roomtype: {
                            ID: $(item).data('id')
                        }
                    });
                });
                $.ajax({
                    url: '/Booking/UpdateChildren',
                    data: { bookingModel: JSON.stringify(bookingList) },
                    dataType: 'json',
                    type: 'POST',
                    success: function (res) {
                        if (res.status == true) {
                            window.location.href = "/home";
                        }
                    }
                })
            })
        });
    }
}
booking.init();