/*-------------------------------------------------------------------------------------------------------------
DATE			DEVELOPER					MOFIFIER			PURPOSE
=====			==========					=========			=======
17-07-2013		PrabaaKaran										Get fee Details for New Admisssion	
-------------------------------------------------------------------------------------------------------------*/
-- DBSP_DAILY_FEECOLLECTION_REPORT '2013/07/24','2013/07/25',2
CREATE PROCEDURE DBSP_DAILY_FEECOLLECTION_REPORT
	@FromDate	DATETIME,
	@ToDate		DATETIME,
	@SchoolID	INT
AS
BEGIN
	SET NOCOUNT ON
	
	CREATE TABLE #DAILY_FEECOLLECTION
	(
		PaidByCash			NUMERIC(18,2) DEFAULT(0),
		PaidByCheque		NUMERIC(18,2) DEFAULT(0),
		PaidByMaster		NUMERIC(18,2) DEFAULT(0),
		PaidByTT			NUMERIC(18,2) DEFAULT(0),
		PaidByVisa			NUMERIC(18,2) DEFAULT(0),	
		PaidByCreditCard	NUMERIC(18,2) DEFAULT(0),
		Total				NUMERIC(18,2) DEFAULT(0),	
		PaidDate			VARCHAR(10)	
	)
	INSERT INTO #DAILY_FEECOLLECTION
		SELECT 
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			CONVERT(VARCHAR(10), TA.dttransactiondate , 111)	[PaidDate]
		FROM tblaccounttransaction TA
		
		JOIN tblStudentReceipt SR ON
		SR.intSchool = TA.intschool
		AND SR.intTransactionID = TA.inttransactionid
		AND SR.intCancel = TA.intcancel
		AND SR.intCancel = 0
		AND TA.intschool = @SchoolID
		AND CONVERT(VARCHAR(10), TA.dttransactiondate , 111) >= @FromDate
		AND CONVERT(VARCHAR(10), TA.dttransactiondate , 111) < DATEADD(dd,1,@ToDate)
		
		GROUP BY CONVERT(VARCHAR(10), TA.dttransactiondate , 111)
	
	--UPDATE CASH COLLECTION	
	UPDATE #DAILY_FEECOLLECTION SET #DAILY_FEECOLLECTION.PaidByCash = #Temp.PaidAmount FROM 
		(SELECT 
			SUM(TA.intamount)		[PaidAmount],
			CONVERT(VARCHAR(10), TA.dttransactiondate , 111)	[PaidDate]
		FROM tblaccounttransaction TA
		
		JOIN tblStudentReceipt SR ON
		SR.intSchool = TA.intschool
		AND SR.intTransactionID = TA.inttransactionid
		AND SR.intCancel = TA.intcancel
		AND SR.intCancel = 0
		AND TA.intschool = @SchoolID
		AND CONVERT(VARCHAR(10), TA.dttransactiondate , 111) >= @FromDate
		AND CONVERT(VARCHAR(10), TA.dttransactiondate , 111) < DATEADD(dd,1,@ToDate)
		AND TA.strmodeofpayment = 'Cash'
		
		GROUP BY CONVERT(VARCHAR(10), TA.dttransactiondate , 111) ) #Temp
	WHERE #DAILY_FEECOLLECTION.PaidDate = #Temp.PaidDate
	
	--UPDATE CHEQUE COLLECTION	
	UPDATE #DAILY_FEECOLLECTION SET #DAILY_FEECOLLECTION.PaidByCheque = #Temp.PaidAmount FROM 
		(SELECT 
			SUM(TA.intamount)		[PaidAmount],
			CONVERT(VARCHAR(10), TA.dttransactiondate , 111)	[PaidDate]
		FROM tblaccounttransaction TA
		
		JOIN tblStudentReceipt SR ON
		SR.intSchool = TA.intschool
		AND SR.intTransactionID = TA.inttransactionid
		AND SR.intCancel = TA.intcancel
		AND SR.intCancel = 0
		AND TA.intschool = @SchoolID
		AND CONVERT(VARCHAR(10), TA.dttransactiondate , 111) >= @FromDate
		AND CONVERT(VARCHAR(10), TA.dttransactiondate , 111) < DATEADD(dd,1,@ToDate)
		AND TA.strmodeofpayment = 'Cheque'
		
		GROUP BY CONVERT(VARCHAR(10), TA.dttransactiondate , 111) ) #Temp
	WHERE #DAILY_FEECOLLECTION.PaidDate = #Temp.PaidDate
	
	
	--UPDATE MASTER COLLECTION	
	UPDATE #DAILY_FEECOLLECTION SET #DAILY_FEECOLLECTION.PaidByMaster = #Temp.PaidAmount FROM 
		(SELECT 
			SUM(TA.intamount)		[PaidAmount],
			CONVERT(VARCHAR(10), TA.dttransactiondate , 111)	[PaidDate]
		FROM tblaccounttransaction TA
		
		JOIN tblStudentReceipt SR ON
		SR.intSchool = TA.intschool
		AND SR.intTransactionID = TA.inttransactionid
		AND SR.intCancel = TA.intcancel
		AND SR.intCancel = 0
		AND TA.intschool = @SchoolID
		AND CONVERT(VARCHAR(10), TA.dttransactiondate , 111) >= @FromDate
		AND CONVERT(VARCHAR(10), TA.dttransactiondate , 111) < DATEADD(dd,1,@ToDate)
		AND TA.strmodeofpayment = 'Master'
		
		GROUP BY CONVERT(VARCHAR(10), TA.dttransactiondate , 111) ) #Temp
	WHERE #DAILY_FEECOLLECTION.PaidDate = #Temp.PaidDate
	
	
	-- UPDATE TT COLLECTION	
	UPDATE #DAILY_FEECOLLECTION SET #DAILY_FEECOLLECTION.PaidByTT = #Temp.PaidAmount FROM 
		(SELECT 
			SUM(TA.intamount)		[PaidAmount],
			CONVERT(VARCHAR(10), TA.dttransactiondate , 111)	[PaidDate]
		FROM tblaccounttransaction TA
		
		JOIN tblStudentReceipt SR ON
		SR.intSchool = TA.intschool
		AND SR.intTransactionID = TA.inttransactionid
		AND SR.intCancel = TA.intcancel
		AND SR.intCancel = 0
		AND TA.intschool = @SchoolID
		AND CONVERT(VARCHAR(10), TA.dttransactiondate , 111) >= @FromDate
		AND CONVERT(VARCHAR(10), TA.dttransactiondate , 111) < DATEADD(dd,1,@ToDate)
		AND TA.strmodeofpayment = 'TT'
		
		GROUP BY CONVERT(VARCHAR(10), TA.dttransactiondate , 111) ) #Temp
	WHERE #DAILY_FEECOLLECTION.PaidDate = #Temp.PaidDate
	
	--UPDATE VISA COLLECTION	
	UPDATE #DAILY_FEECOLLECTION SET #DAILY_FEECOLLECTION.PaidByVisa = #Temp.PaidAmount FROM 
		(SELECT 
			SUM(TA.intamount)		[PaidAmount],
			CONVERT(VARCHAR(10), TA.dttransactiondate , 111)	[PaidDate]
		FROM tblaccounttransaction TA
		
		JOIN tblStudentReceipt SR ON
		SR.intSchool = TA.intschool
		AND SR.intTransactionID = TA.inttransactionid
		AND SR.intCancel = TA.intcancel
		AND SR.intCancel = 0
		AND TA.intschool = @SchoolID
		AND CONVERT(VARCHAR(10), TA.dttransactiondate , 111) >= @FromDate
		AND CONVERT(VARCHAR(10), TA.dttransactiondate , 111) < DATEADD(dd,1,@ToDate)
		AND TA.strmodeofpayment = 'Visa'
		
		GROUP BY CONVERT(VARCHAR(10), TA.dttransactiondate , 111) ) #Temp
	WHERE #DAILY_FEECOLLECTION.PaidDate = #Temp.PaidDate
	
	-- UPDATE CREDIT CARD COLLECTION	
	UPDATE #DAILY_FEECOLLECTION SET #DAILY_FEECOLLECTION.PaidByCreditCard = #Temp.PaidAmount FROM 
		(SELECT 
			SUM(TA.intamount)		[PaidAmount],
			CONVERT(VARCHAR(10), TA.dttransactiondate , 111)	[PaidDate]
		FROM tblaccounttransaction TA
		
		JOIN tblStudentReceipt SR ON
		SR.intSchool = TA.intschool
		AND SR.intTransactionID = TA.inttransactionid
		AND SR.intCancel = TA.intcancel
		AND SR.intCancel = 0
		AND TA.intschool = @SchoolID
		AND CONVERT(VARCHAR(10), TA.dttransactiondate , 111) >= @FromDate
		AND CONVERT(VARCHAR(10), TA.dttransactiondate , 111) < DATEADD(dd,1,@ToDate)
		AND TA.strmodeofpayment = 'Credit Card'
		
		GROUP BY CONVERT(VARCHAR(10), TA.dttransactiondate , 111) ) #Temp
	WHERE #DAILY_FEECOLLECTION.PaidDate = #Temp.PaidDate
	
	-- UPDATE CREDIT CARD COLLECTION	
	UPDATE #DAILY_FEECOLLECTION SET 
	#DAILY_FEECOLLECTION.Total =  (PaidByCash + PaidByCheque + PaidByCreditCard + PaidByMaster + PaidByTT + PaidByVisa )
	FROM #DAILY_FEECOLLECTION
	WHERE #DAILY_FEECOLLECTION.PaidDate = #DAILY_FEECOLLECTION.PaidDate
		
	SELECT * FROM #DAILY_FEECOLLECTION
	
	DROP TABLE #DAILY_FEECOLLECTION
END