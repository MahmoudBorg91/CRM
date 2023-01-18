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

        var newRequest_count = 0;
        var requestSubmation_count = 0;
        var requsetToPayment_count = '';
        var requestPaymentDone_count = '';
        var requestUnderProcessing_count = '';
        var requestDone_count = ''
        var requestMissingInformation_count = '';
        var requestMissingProcessing_count = '';
        var requestRejectFromUS_count = '';
        var requestRejectFromEntity_count = '';
        var requestTransferAllUser = '';
        var requestTransferOneUser = '';
        var requestAll_count = '';

        $.ajax({
            url: '/Dashboard/loadRequest',
                method: 'GET',
            success: (result) => {
                $.each(result,
                    (k, v) => {


                        newRequest_count = `${v.newRequest_count}`;
                        requestSubmation_count = `${v.requestSubmation_count}`;
                        requsetToPayment_count = `${v.requsetToPayment_count}`;
                        requestPaymentDone_count = `${v.requestPaymentDone_count}`;
                        requestUnderProcessing_count = `${v.requestUnderProcessing_count}`;
                        requestDone_count = `${v.requestDone_count}`;
                        requestMissingInformation_count = `${v.requestMissingInformation_count}`;
                        requestMissingProcessing_count = `${v.requestMissingProcessing_count}`;
                        requestRejectFromUS_count = `${v.requestRejectFromUS_count}`;
                        requestRejectFromEntity_count = `${v.requestRejectFromEntity_count}`;
                        requestTransferAllUser = `${v.requestTransferAllUser}`;
                        requestTransferOneUser = `${v.requestTransferOneUser}`;
                        requestAll_count = `${v.requestAll_count}`;

                    });
                console.log(newRequest_count);
                $("#newRequest_count").text(newRequest_count);
                $("#requestSubmation_count").text(requestSubmation_count);
                $("#requsetToPayment_count").text(requsetToPayment_count);
                $("#requestPaymentDone_count").text(requestPaymentDone_count);
                $("#requestUnderProcessing_count").text(requestUnderProcessing_count);
                $("#requestDone_count").text(requestDone_count);
                $("#requestMissingInformation_count").text(requestMissingInformation_count);
                $("#requestMissingProcessing_count").text(requestMissingProcessing_count);
                $("#requestRejectFromUS_count").text(requestRejectFromUS_count);
                $("#requestRejectFromEntity_count").text(requestRejectFromEntity_count);
                $("#requestTransferAllUser").text(requestTransferAllUser);
                $("#requestTransferOneUser").text(requestTransferOneUser);
                $("#requestAll_count").text(requestAll_count);
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
                        StartTransactionTime = `${v.startTransactionTime}`;
                        EndTransactionTime = `${v.endTransactionTime}`;
                        UserID = `${v.userID}`;
                        TimeEnd = `${v.timeEnd}`;
                        

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
                console.log(result);
                $.each(result,
                    (k, v) => {



                    




                        tr += `

                              <tr>
                                  <td>""</td>
                             <td>${v.id}</td>
                             <td>${v.the_Date}</td>
                             <td>${v.clientName}<br>${v.clientLastName}</td>
                             <td>${v.clientPhone}<br>${v.userEmail}</td>
                             <td>${v.country_Name}</td>
                             <td >${v.transiactionItem_NameEnglish}</td>
                             <td>${v.transiactionItem_Name}</td>
                             <td >${v.numberOfTransiactionOfEntity}</td>
                             <td>${v.transiactionItem_Price}<br>${v.transiactionItem_GovernmentFees}</td>
                             <td><a href="/Dashboard/CheckRequestApplicationToOpen/${v.id
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
                             <td>${v.id}</td>
                             <td>${v.the_Date}</td>
                             <td>${v.clientName}<br>${v.clientLastName}</td>
                             <td>${v.clientPhone}<br>${v.userEmail}</td>
                             <td>${v.country_Name}</td>
                             <td >${v.transiactionItem_NameEnglish}</td>
                             <td>${v.transiactionItem_Name}</td>
                             <td >${v.numberOfTransiactionOfEntity}</td>
                             <td>${v.transiactionItem_Price}<br>${v.transiactionItem_GovernmentFees}</td>
                             <td><a href="/Dashboard/GetAppLicationToReview/${v.id
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
