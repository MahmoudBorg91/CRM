//$(document).ready(function () {
//    $("#example1").DataTable({
//        "responsive": true, "lengthChange": false, "autoWidth": false,
//        "buttons": ["copy", "csv", "excel", "pdf", "print", "colvis"]
//    }).buttons().container().appendTo('#example_wrapper .col-md-6:eq(0)');

//    var minDate, maxDate;

//     Custom filtering function which will search data in column four between two values
//    $.fn.dataTable.ext.search.push(
//        function (settings, data, dataIndex) {
//            var min = minDate.val();
//            var max = maxDate.val();
//            var date = new Date(data[7]);

//            if (
//                (min === null && max === null) ||
//                (min === null && date <= max) ||
//                (min <= date && max === null) ||
//                (min <= date && date <= max)
//            ) {
//                return true;
//            }
//            return false;
//        }
//    );

//    minDate = new DateTime($('#min'), {
//        format: 'MMMM Do YYYY'
//    });
//    maxDate = new DateTime($('#max'), {
//        format: 'MMMM Do YYYY'
//    });

//     DataTables initialisation
//    var table = $('#example1').DataTable();

//     Refilter the table
//    $('#min, #max').on('change', function () {
//        table.draw();
//    });





//});

//var minDate, maxDate;

// Custom filtering function which will search data in column four between two values
//$.fn.dataTable.ext.search.push(
//    function (settings, data, dataIndex) {
//        var min = minDate.val();
//        var max = maxDate.val();
//        var date = new Date(data[7]).toLocaleString().split('/')[0];
//        alert(date)
//        if (
//            (min === null && max === null) ||
//            (min === null && date <= max) ||
//            (min <= date && max === null) ||
//            (min <= date && date <= max)
//        ) {
//            return true;
//        }
//        return false;
//    }
//);

//$(document).ready(function () {
//     Create date inputs
//    minDate = new DateTime($('#min'), {
//        format: 'MM/dd/yyyy'
//    });
//    maxDate = new DateTime($('#max'), {
//        format: 'MM/dd/yyyy'
//    });

//     DataTables initialisation
//    var table = $('#example1').DataTable();

//     Refilter the table
//    $('#min, #max').on('change', function () {
//        table.draw();
//    });
//});



