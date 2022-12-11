// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(() => {
    loadRequest();
    var connection = new signalR.HubConnectionBuilder().withUrl("/signalrServer").build();
    connection.start();

    connection.on("loadRequests",
        function() {
            loadRequest();
            GetAppLicationBySignalRStatus();
        });
    connection.on("RefreshRequest",
        function () {
           
            GetAppLicationBySignalRStatus();
        });
    connection.on("checkTransactTime",
        function () {

            checkTransactTimeBySignalR();
        });

   
    loadRequest();
    GetAppLicationBySignalRStatus();
    checkTransactTimeBySignalR();
    function loadRequest() {

        var NewRequest_count = 0;
        var RequestSubmation_count = 0;
        var RequsetToPayment_count = '';
        var RequestPaymentDone_count = '';
        var RequestUnderProcessing_count = '';
        var RequestDone_count = ''
        var RequestMissingInformation_count = '';
        var RequestMissingProcessing_count = '';
        var RequestRejectFromUS_count = '';
        var RequestRejectFromEntity_count = '';
        var RequestTransferAllUser = '';
        var RequestTransferOneUser = '';
        var RequestAll_count = '';

        $.ajax({
            url: '/Dashboard/loadRequest',
                method: 'GET',
            success: (result) => {
                $.each(result,
                    (k, v) => {


                        NewRequest_count = `${v.NewRequest_count}`;
                        RequestSubmation_count = `${v.RequestSubmation_count}`;
                        RequsetToPayment_count = `${v.RequsetToPayment_count}`;
                        RequestPaymentDone_count = `${v.RequestPaymentDone_count}`;
                        RequestUnderProcessing_count = `${v.RequestUnderProcessing_count}`;
                        RequestDone_count = `${v.RequestDone_count}`;
                        RequestMissingInformation_count = `${v.RequestMissingInformation_count}`;
                        RequestMissingProcessing_count = `${v.RequestMissingProcessing_count}`;
                        RequestRejectFromUS_count = `${v.RequestRejectFromUS_count}`;
                        RequestRejectFromEntity_count = `${v.RequestRejectFromEntity_count}`;
                        RequestTransferAllUser = `${v.RequestTransferAllUser}`;
                        RequestTransferOneUser = `${v.RequestTransferOneUser}`;
                        RequestAll_count = `${v.RequestAll_count}`;

                    });
                console.log(NewRequest_count);
                $("#NewRequest_count").text(NewRequest_count);
                $("#RequestSubmation_count").text(RequestSubmation_count);
                $("#RequsetToPayment_count").text(RequsetToPayment_count);
                $("#RequestPaymentDone_count").text(RequestPaymentDone_count);
                $("#RequestUnderProcessing_count").text(RequestUnderProcessing_count);
                $("#RequestDone_count").text(RequestDone_count);
                $("#RequestMissingInformation_count").text(RequestMissingInformation_count);
                $("#RequestMissingProcessing_count").text(RequestMissingProcessing_count);
                $("#RequestRejectFromUS_count").text(RequestRejectFromUS_count);
                $("#RequestRejectFromEntity_count").text(RequestRejectFromEntity_count);
                $("#RequestTransferAllUser").text(RequestTransferAllUser);
                $("#RequestTransferOneUser").text(RequestTransferOneUser);
                $("#RequestAll_count").text(RequestAll_count);
                //  console.log($("#NewRequest_count").text);
            },
                error:
                    (error) => {
                        console.log(error);

                    }
            
        });
                

           


 
    }

    function checkTransactTimeBySignalR() {

        var ID ;
        var StartTransactionTime ;
        var EndTransactionTime ;
        var UserID;
        var TimeEnd;
        var url = $(location).attr('href');
        
        var id = url.substring(url.lastIndexOf("/") + 1);
       
        $.ajax({

           
            url: "/Dashboard/checkTransactTimes/"+id+"",
            method: 'GET',
            success: (result) => {
                $.each(result,
                    (k, v) => {


                        ID = `${v.ID}`;
                        StartTransactionTime = `${v.StartTransactionTime}`;
                        EndTransactionTime = `${v.EndTransactionTime}`;
                        UserID = `${v.UserID}`;
                        TimeEnd = `${v.TimeEnd}`;
                        

                    });
               // var trans_time = TimeEnd
                
                startCountDown(TimeEnd * 60 );
                function startCountDown(timeleft) {
                    var interval = setInterval(countdown, 1000);
                    update();

                    function countdown() {
                        if (--timeleft > 0) {
                            update();

                        } else {
                            clearInterval(interval);
                            update();
                            complete();
                        }
                    }


                    function update() {

                        hours = Math.floor(timeleft / 3600);
                        minutes = Math.floor((timeleft % 3600) / 60);
                        seconds = timeleft % 60;
                        document.getElementById('lblTimer').innerHTML = '' + hours.toString() + ':' + minutes.toString() + ':' + seconds.toString();
                        //console.log(seconds.toString());
                        //console.log(hours.toString());
                        //console.log(minutes.toString());
                    }
                   
                    function complete() {
                        document.write("Your Time  Ended in this  Transaction You will go Dashboard Page Thank You Please Wait 5 Second");
                        var url2 = '@Url.Action("Index", "Dashboard")';
                       
                        setTimeout(function () {
                            window.location.href.replace(url2);
                                //  location.href = '@Url.Action("Index", "Dashboard")';
                                //  window.location.href = url;
                            },
                            5000);

                    }
                }
                console.log(StartTransactionTime);

                //  console.log($("#NewRequest_count").text);
            },
            error:
                (error) => {
                    console.log(error);

                }

        });






    }

    function GetAppLicationBySignalRStatus( ) {
        var url = $(location).attr('href');

        var parts = url.split("/");
        var status = parts[parts.length - 1];
       // alert(last_part);
        var tr = ''
        $.ajax({
           
            url: "/Dashboard/GetAppLicationBySignalRStatus/"+status+"",
            method: 'GET',
            success: (result) => {
                $.each(result,
                    (k, v) => {



                    




                        tr += `

                              <tr>
                                  <td>""</td>
                             <td>${v.ID}</td>
                             <td>${v.The_Date}</td>
                             <td>${v.ClientName}<br>${v.ClientLastName}</td>
                             <td>${v.ClientPhone}<br>${v.UserEmail}</td>
                             <td>${v.Country_Name}</td>
                             <td >${v.TransiactionItem_NameEnglish}</td>
                             <td>${v.TransiactionItem_Name}</td>
                             <td >${v.NumberOfTransiactionOfEntity}</td>
                             <td>${v.TransiactionItem_Price}<br>${v.TransiactionItem_GovernmentFees}</td>
                             <td><a href="/Dashboard/CheckRequestApplicationToOpen/${v.ID
                            }" class="btn btn-warning">Check</a></td>
                              <tr>`;


                    });
                $("#tblBody").html(tr);

                //  console.log($("#NewRequest_count").text);
            },
            error:
                (error) => {
                    console.log(error);

                }

        });
    }

    function GetAppLicationBySignalRToprocess() {
        var url = $(location).attr('href');
        var AppID = url.split("/").pop();
        var status = parts[parts.length - 1];
        // alert(last_part);
        var tr = ''
        $.ajax({

            url: "/Dashboard/GetAppLicationBySignalRStatus/" + status + "",
            method: 'GET',
            success: (result) => {
                $.each(result,
                    (k, v) => {








                        tr += `

                              <tr>
                                  <td>""</td>
                             <td>${v.ID}</td>
                             <td>${v.The_Date}</td>
                             <td>${v.ClientName}<br>${v.ClientLastName}</td>
                             <td>${v.ClientPhone}<br>${v.UserEmail}</td>
                             <td>${v.Country_Name}</td>
                             <td >${v.TransiactionItem_NameEnglish}</td>
                             <td>${v.TransiactionItem_Name}</td>
                             <td >${v.NumberOfTransiactionOfEntity}</td>
                             <td>${v.TransiactionItem_Price}<br>${v.TransiactionItem_GovernmentFees}</td>
                             <td><a href="/Dashboard/GetAppLicationToReview/${v.ID
                            }" class="btn btn-warning">Check</a></td>
                              <tr>`;


                    });
                $("#tblBody").html(tr);

                //  console.log($("#NewRequest_count").text);
            },
            error:
                (error) => {
                    console.log(error);

                }

        });
    }
})
