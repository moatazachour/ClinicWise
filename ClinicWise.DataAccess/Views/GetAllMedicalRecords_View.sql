alter view GetAllMedicalRecords_View
as
with MedicalRecordData
as
(
	select
		RecordID,
		AppointmentID,
		VisitTypeLabel =
			case
				when VisitType = 1 then 'Consultation'
				when VisitType = 2 then 'Follow Up'
				when VisitType = 3 then 'Emergency'
				when VisitType = 4 then 'Routine Check'
				when VisitType = 5 then 'Vaccination'
				when VisitType = 6 then 'Lab Test'
				else 'Consultation'
			end,
		DescriptionOfVisit,
		Diagnosis
	from
		MedicalRecords
)
select * from MedicalRecordData;