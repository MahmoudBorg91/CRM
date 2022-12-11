



////fetch products




//$(document).ready(function () {

//    //var items = "<option value='0'>Select</option>";
//    //$('#AppDRB').html(items);


//    //$('#SolutionID').change(function () {

//    //    var x = $('#SolutionID').val();
        

//    //    var url = Url.Content("~/") + "DemoRequest/getApplication";
//    //    alert(url).text;

//    //    var ddlsource = "#SolutionID";

//    //    $.getJSON(url, { ID: $(ddlsource).val() }, function (data) {

//    //        var items = '';
//    //        $('#AppDRB').empty();

//    //        $.each(data, function (i, app) {
//    //            items += "<option value='" + app.val + "'>" + app.text + "</option>"

//    //        });
//    //            $('#AppDRB').html(items);
//    //        });
//    //    });

  

//        //Add button click event
//        //$('#add').click(function () {
//        //    //validation and add order items
//        //    var isAllValid = true;
//        //    if ($('#SolutionID').val() == "0") {
//        //        isAllValid = false;
//        //        $('#SolutionID').siblings('span.error').css('visibility', 'visible');
//        //    }
//        //    else {
//        //        $('#SolutionID').siblings('span.error').css('visibility', 'hidden');
//        //    }

//        //    if ($('#AppDRB').val() == "0") {
//        //        isAllValid = false;
//        //        $('#AppDRB').siblings('span.error').css('visibility', 'visible');
//        //    }
//        //    else {
//        //        $('#AppDRB').siblings('span.error').css('visibility', 'hidden');
//        //    }

//        //    if (!($('#quantity').val().trim() != '' && (parseInt($('#quantity').val()) || 0))) {
//        //        isAllValid = false;
//        //        $('#quantity').siblings('span.error').css('visibility', 'visible');
//        //    }
//        //    else {
//        //        $('#quantity').siblings('span.error').css('visibility', 'hidden');
//        //    }

//        //    if (!($('#rate').val().trim() != '' && !isNaN($('#rate').val().trim()))) {
//        //        isAllValid = false;
//        //        $('#rate').siblings('span.error').css('visibility', 'visible');
//        //    }
//        //    else {
//        //        $('#rate').siblings('span.error').css('visibility', 'hidden');
//        //    }

//        //    if (isAllValid) {
                
//        //        var $newRow = $('#mainrow').clone().removeAttr('id');
//        //        $('.pc', $newRow).val($('#SolutionID').val());
//        //        $('.product', $newRow).val($('#AppDRB').val());

//        //        var x = $(".pc option:selected").val()
//        //        var y = $(".pc option:selected").text()

//        //        var xx = $(".product option:selected").val()
//        //        var yy = $(".product option:selected").text()

//        //        alert(xx);
//        //        alert(yy);



//        //        //Replace add button with remove button
//        //        $('#add', $newRow).addClass('remove').val('Remove').removeClass('btn-success').addClass('btn-danger');

//        //        //remove id attribute from new clone row
//        //        $('#SolutionID,#AppDRB,#quantity,#rate,#add', $newRow).removeAttr('id');
//        //        $('span.error', $newRow).remove();
//        //        //append clone row
//        //        $('#orderdetailsItems').append($newRow);
               
//        //        //clear select data
//        //        $('#SolutionID,#AppDRB').val('0');
//        //        $('#quantity,#rate').val('');
//        //        $('#orderItemError').empty();
//        //    }

//        //})

//        //remove button click event
//        $('#orderdetailsItems').on('click', '.remove', function () {
//            $(this).parents('tr').remove();
//        });

//        $('#submit').click(function () {
//            var isAllValid = true;

//            //validate order items
//            $('#orderItemError').text('');
//            var list = [];
//            var errorItemCount = 0;
//            $('#orderdetailsItems tbody tr').each(function (index, ele) {
//                if (
//                    $('select.product', this).val() == "0" ||
//                    (parseInt($('.quantity', this).val()) || 0) == 0 ||
//                    $('.rate', this).val() == "" ||
//                    isNaN($('.rate', this).val())
//                ) {
//                    errorItemCount++;
//                    $(this).addClass('error');
//                } else {
//                    var orderItem = {
//                        ProductID: $('select.product', this).val(),
//                        Quantity: parseInt($('.quantity', this).val()),
//                        Rate: parseFloat($('.rate', this).val())
//                    }
//                    list.push(orderItem);
//                }
//            })

//            if (errorItemCount > 0) {
//                $('#orderItemError').text(errorItemCount + " invalid entry in order item list.");
//                isAllValid = false;
//            }

//            if (list.length == 0) {
//                $('#orderItemError').text('At least 1 order item required.');
//                isAllValid = false;
//            }

//            if ($('#orderNo').val().trim() == '') {
//                $('#orderNo').siblings('span.error').css('visibility', 'visible');
//                isAllValid = false;
//            }
//            else {
//                $('#orderNo').siblings('span.error').css('visibility', 'hidden');
//            }

//            if ($('#orderDate').val().trim() == '') {
//                $('#orderDate').siblings('span.error').css('visibility', 'visible');
//                isAllValid = false;
//            }
//            else {
//                $('#orderDate').siblings('span.error').css('visibility', 'hidden');
//            }

//            if (isAllValid) {
//                var data = {
//                    OrderNo: $('#orderNo').val().trim(),
//                    OrderDateString: $('#orderDate').val().trim(),
//                    Description: $('#description').val().trim(),
//                    OrderDetails: list
//                }

//                $(this).val('Please wait...');

//                $.ajax({
//                    type: 'POST',
//                    url: '/home/save',
//                    data: JSON.stringify(data),
//                    contentType: 'application/json',
//                    success: function (data) {
//                        if (data.status) {
//                            alert('Successfully saved');
//                            //here we will clear the form
//                            list = [];
//                            $('#orderNo,#orderDate,#description').val('');
//                            $('#orderdetailsItems').empty();
//                        }
//                        else {
//                            alert('Error');
//                        }
//                        $('#submit').val('Save');
//                    },
//                    error: function (error) {
//                        console.log(error);
//                        $('#submit').val('Save');
//                    }
//                });
//            }

//        });

//    });


