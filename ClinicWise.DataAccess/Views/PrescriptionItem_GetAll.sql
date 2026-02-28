create view PrescriptionItem_GetAll
as
select
	p.ItemID,
	p.RecordID,
	p.MedicamentID,
	m.Brand,
	m.Name,
	m.DosageForm,
	p.Dosage,
	p.Frequency,
	p.Duration,
	p.SpecialInstruction,
	p.IsForever
from
	PrescriptionItems p
		inner join Medicaments m
		on p.MedicamentID = m.MedicamentID;