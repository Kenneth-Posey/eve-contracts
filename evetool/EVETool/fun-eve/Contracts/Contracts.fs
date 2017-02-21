namespace FunEve.Contracts

module Contracts = 
    open System
    open FSharp.Data
    open System.Net
    
    type XmlCourierContractListing = XmlProvider<"""<?xml version='1.0' encoding='UTF-8'?>
        <eveapi version="2">
          <currentTime>2016-10-10 05:45:29</currentTime>
          <result>
            <rowset name="contractList" key="contractID" columns="contractID,issuerID,issuerCorpID,assigneeID,acceptorID,startStationID,endStationID,type,status,title,forCorp,availability,dateIssued,dateExpired,dateAccepted,numDays,dateCompleted,price,reward,collateral,buyout,volume">
              <row contractID="108756260" issuerID="96514211" issuerCorpID="98142371" assigneeID="1590527270" acceptorID="98142371" startStationID="1021705628874" endStationID="1021705628874" type="ItemExchange" status="Completed" title="" forCorp="0" availability="Private" dateIssued="2016-09-17 19:25:43" dateExpired="2016-10-01 19:25:43" dateAccepted="2016-09-17 19:25:58" numDays="0" dateCompleted="2016-09-17 19:25:58" price="0.00" reward="0.00" collateral="0.00" buyout="0.00" volume="570300" />
              <row contractID="108829059" issuerID="96514211" issuerCorpID="98142371" assigneeID="1590527270" acceptorID="98142371" startStationID="60003760" endStationID="60003760" type="ItemExchange" status="Completed" title="" forCorp="0" availability="Private" dateIssued="2016-09-19 20:46:39" dateExpired="2016-10-03 20:46:39" dateAccepted="2016-09-19 20:58:02" numDays="0" dateCompleted="2016-09-19 20:58:02" price="0.00" reward="0.00" collateral="0.00" buyout="0.00" volume="900000" />
              <row contractID="108897838" issuerID="96514211" issuerCorpID="98142371" assigneeID="1590527270" acceptorID="98142371" startStationID="1021964194425" endStationID="1021964194425" type="ItemExchange" status="Completed" title="" forCorp="0" availability="Private" dateIssued="2016-09-22 06:33:31" dateExpired="2016-10-06 06:33:31" dateAccepted="2016-09-22 06:33:47" numDays="0" dateCompleted="2016-09-22 06:33:47" price="0.00" reward="0.00" collateral="0.00" buyout="0.00" volume="984400" />
            </rowset>
          </result>
          <cachedUntil>2016-10-10 05:56:46</cachedUntil>
        </eveapi>
        """>

    type XmlCourierContractRow = XmlProvider<"""
            <row contractID="109299255" issuerID="1590527270" issuerCorpID="98142371" assigneeID="0" acceptorID="94595444" startStationID="60003679" endStationID="60003760" type="Courier" status="Completed" title="Check the contract search; we're always shipping!" forCorp="1" availability="Public" dateIssued="2016-10-05 01:37:09" dateExpired="2016-10-19 01:37:09" dateAccepted="2016-10-05 02:07:13" numDays="1" dateCompleted="2016-10-05 04:03:14" price="0.00" reward="24500000.00" collateral="1750000000.00" buyout="0.00" volume="200000" />
        """>

    type XmlItemExchangeContractListing = XmlProvider<"""
        <eveapi version="2">
          <currentTime>2017-01-06 03:17:25</currentTime>
          <result>
            <rowset name="contractList" key="contractID" columns="contractID,issuerID,issuerCorpID,assigneeID,acceptorID,startStationID,endStationID,type,status,title,forCorp,availability,dateIssued,dateExpired,dateAccepted,numDays,dateCompleted,price,reward,collateral,buyout,volume">
              <row contractID="111583685" issuerID="1590527270" issuerCorpID="98142371" assigneeID="96868921" acceptorID="98482641" startStationID="60003760" endStationID="60003760" type="ItemExchange" status="Completed" title="" forCorp="1" availability="Private" dateIssued="2016-12-08 06:19:35" dateExpired="2016-12-22 06:19:35" dateAccepted="2016-12-08 06:31:26" numDays="0" dateCompleted="2016-12-08 06:31:26" price="0.00" reward="0.00" collateral="0.00" buyout="0.00" volume="119600" />
              <row contractID="112073905" issuerID="1590527270" issuerCorpID="98142371" assigneeID="96715064" acceptorID="96715064" startStationID="60012667" endStationID="60012667" type="ItemExchange" status="Completed" title="" forCorp="0" availability="Private" dateIssued="2016-12-18 19:44:11" dateExpired="2017-01-01 19:44:11" dateAccepted="2016-12-18 19:44:21" numDays="0" dateCompleted="2016-12-18 19:44:21" price="0.00" reward="0.00" collateral="0.00" buyout="0.00" volume="75000" />
              <row contractID="112233192" issuerID="1590527270" issuerCorpID="98142371" assigneeID="96868921" acceptorID="98482641" startStationID="60012667" endStationID="60012667" type="ItemExchange" status="Completed" title="" forCorp="0" availability="Private" dateIssued="2016-12-21 19:20:41" dateExpired="2017-01-04 19:20:41" dateAccepted="2016-12-21 19:28:56" numDays="0" dateCompleted="2016-12-21 19:28:56" price="0.00" reward="0.00" collateral="0.00" buyout="0.00" volume="80000" />
            </rowset>
          </result>
          <cachedUntil>2017-01-06 03:23:08</cachedUntil>
        </eveapi>
        """>

    type XmlItemExchangeContractRow = XmlProvider<"""
            <row contractID="112073905" issuerID="1590527270" issuerCorpID="98142371" assigneeID="96715064" acceptorID="96715064" startStationID="60012667" endStationID="60012667" type="ItemExchange" status="Completed" title="" forCorp="0" availability="Private" dateIssued="2016-12-18 19:44:11" dateExpired="2017-01-01 19:44:11" dateAccepted="2016-12-18 19:44:21" numDays="0" dateCompleted="2016-12-18 19:44:21" price="0.00" reward="0.00" collateral="0.00" buyout="0.00" volume="75000" />
        """>
                
    type XmlMixedContractListing = XmlProvider<"""
        <eveapi version="2">
          <currentTime>2017-01-06 03:17:25</currentTime>
          <result>
            <rowset name="contractList" key="contractID" columns="contractID,issuerID,issuerCorpID,assigneeID,acceptorID,startStationID,endStationID,type,status,title,forCorp,availability,dateIssued,dateExpired,dateAccepted,numDays,dateCompleted,price,reward,collateral,buyout,volume">
              <row contractID="111583685" issuerID="1590527270" issuerCorpID="98142371" assigneeID="96868921" acceptorID="98482641" startStationID="60003760" endStationID="60003760" type="ItemExchange" status="Completed" title="" forCorp="1" availability="Private" dateIssued="2016-12-08 06:19:35" dateExpired="2016-12-22 06:19:35" dateAccepted="2016-12-08 06:31:26" numDays="0" dateCompleted="2016-12-08 06:31:26" price="0.00" reward="0.00" collateral="0.00" buyout="0.00" volume="119600" />
              <row contractID="112073905" issuerID="1590527270" issuerCorpID="98142371" assigneeID="96715064" acceptorID="96715064" startStationID="60012667" endStationID="60012667" type="ItemExchange" status="Completed" title="" forCorp="0" availability="Private" dateIssued="2016-12-18 19:44:11" dateExpired="2017-01-01 19:44:11" dateAccepted="2016-12-18 19:44:21" numDays="0" dateCompleted="2016-12-18 19:44:21" price="0.00" reward="0.00" collateral="0.00" buyout="0.00" volume="75000" />
              <row contractID="112233192" issuerID="1590527270" issuerCorpID="98142371" assigneeID="96868921" acceptorID="98482641" startStationID="60012667" endStationID="60012667" type="ItemExchange" status="Completed" title="" forCorp="0" availability="Private" dateIssued="2016-12-21 19:20:41" dateExpired="2017-01-04 19:20:41" dateAccepted="2016-12-21 19:28:56" numDays="0" dateCompleted="2016-12-21 19:28:56" price="0.00" reward="0.00" collateral="0.00" buyout="0.00" volume="80000" />
              <row contractID="108756260" issuerID="96514211" issuerCorpID="98142371" assigneeID="1590527270" acceptorID="98142371" startStationID="1021705628874" endStationID="1021705628874" type="ItemExchange" status="Completed" title="" forCorp="0" availability="Private" dateIssued="2016-09-17 19:25:43" dateExpired="2016-10-01 19:25:43" dateAccepted="2016-09-17 19:25:58" numDays="0" dateCompleted="2016-09-17 19:25:58" price="0.00" reward="0.00" collateral="0.00" buyout="0.00" volume="570300" />
              <row contractID="108829059" issuerID="96514211" issuerCorpID="98142371" assigneeID="1590527270" acceptorID="98142371" startStationID="60003760" endStationID="60003760" type="ItemExchange" status="Completed" title="" forCorp="0" availability="Private" dateIssued="2016-09-19 20:46:39" dateExpired="2016-10-03 20:46:39" dateAccepted="2016-09-19 20:58:02" numDays="0" dateCompleted="2016-09-19 20:58:02" price="0.00" reward="0.00" collateral="0.00" buyout="0.00" volume="900000" />
              <row contractID="108897838" issuerID="96514211" issuerCorpID="98142371" assigneeID="1590527270" acceptorID="98142371" startStationID="1021964194425" endStationID="1021964194425" type="ItemExchange" status="Completed" title="" forCorp="0" availability="Private" dateIssued="2016-09-22 06:33:31" dateExpired="2016-10-06 06:33:31" dateAccepted="2016-09-22 06:33:47" numDays="0" dateCompleted="2016-09-22 06:33:47" price="0.00" reward="0.00" collateral="0.00" buyout="0.00" volume="984400" />
            </rowset>
          </result>
          <cachedUntil>2017-01-06 03:23:08</cachedUntil>
        </eveapi>
        """>

    type ApiContractType = 
    | Item
    | Auction
    | Courier

    type ApiContractStatus =
    | Open 
    | InProgress 
    | Completed
    | Failed 

    type ApiQueryPerson = 
    | Character
    | Corp

    type Contract = {
        Status : ApiContractStatus
        Availability : string
        IssueDate : DateTime
        CompleteDate : DateTime option
        AcceptorId : int
        ContractType : ApiContractType
    }
    
    let (|Item|Auction|Courier|) (cText:string) = 
        if cText = "ItemExchange" then Item
        else if cText = "Courier" then Courier
        else Auction
        
    let (|Open|InProgress|Completed|Failed|) (cText:string) = 
        if cText = "Open" then Open
        else if cText = "InProgress" then InProgress
        else if cText = "Completed" then Completed
        else Failed

    let matchContractType cText = 
        match cText with
        | Item -> Item
        | Auction -> Auction
        | Courier -> Courier
                
    let matchContractStatus cText = 
        match cText with
        | Open -> Open
        | InProgress -> InProgress
        | Completed -> Completed
        | Failed -> Failed
        
        

    let contractUrlBase apiPerson = 
        match apiPerson with
        | ApiQueryPerson.Character -> @"https://api.eveonline.com/char/Contracts.xml.aspx"
        | ApiQueryPerson.Corp -> @"https://api.eveonline.com/corp/Contracts.xml.aspx"
        

    let formApiUrl keyId vCode apiPerson = 
        contractUrlBase apiPerson
        |> fun url -> sprintf @"%s?keyID=%s&vCode=%s" url keyId vCode             

    let LoadContractListing keyId vCode apiPerson =                 
        formApiUrl keyId vCode apiPerson
        |> fun xmlUrl -> 
            WebRequest.Create (new Uri(xmlUrl))
        |> fun request -> 
            use resp = request.GetResponse ()         
            use responseStream = resp.GetResponseStream () 
            use responseReader = new IO.StreamReader (responseStream) 
            responseReader.ReadToEnd ()
        |> fun contents -> 
            XmlCourierContractListing.Parse contents
        |> fun response -> 
            [
                for row in response.Result.Rowset.Rows do
                    let dateCompleted = 
                        match row.Status, row.Type with
                        | Completed, Courier -> Some row.DateCompleted
                        | Completed, Item -> Some row.DateAccepted
                        | _ -> None

                    yield {
                        Status = matchContractStatus row.Status
                        Availability = row.Availability
                        IssueDate = row.DateIssued
                        CompleteDate = dateCompleted
                        AcceptorId = row.AcceptorId
                        ContractType = matchContractType row.Type
                    }
                     
            ]
        
    let LoadCorpContracts keyId vCode = 
        LoadContractListing keyId vCode Corp

    let LoadCharacterContracts keyId vCode =
        LoadContractListing keyId vCode Character