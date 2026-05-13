ALTER VIEW GetAllInvoices_View
AS
With InvoiceData
As
(
	SELECT  i.InvoiceID
	  ,i.InvoiceNumber
	  ,i.AppointmentID
	  ,i.PatientID
	  ,p.FirstName + ' ' + p.LastName AS PatientName
	  ,i.TotalAmount
	  ,i.AmountPaid
	  ,i.OutstandingBalance
	  ,i.Status
	  ,case i.Status
		when 0 then 'Draft'
		when 1 then 'Issued'
		when 2 then 'Partially Paid'
		when 3 then 'Paid'
		when 4 then 'Waived'
		when 5 then 'Voided'
		else 'Draft'
	  end as StatusLabel
      ,u.Username AS IssuedBy
  FROM Invoices i 
	INNER JOIN Patients pat
	ON i.PatientID = pat.PatientID
	INNER JOIN Persons p
	ON pat.PersonID = p.PersonID
	LEFT JOIN Users u
	ON i.IssuedByUserID = u.UserID
)
SELECT 
    InvoiceID,
    InvoiceNumber,
    AppointmentID,
    PatientID,
    PatientName,
    TotalAmount,
    AmountPaid,
    OutstandingBalance,
    Status,
    StatusLabel,
    IssuedBy
FROM InvoiceData;