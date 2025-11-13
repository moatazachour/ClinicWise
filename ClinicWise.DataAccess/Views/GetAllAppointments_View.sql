alter view GetAllAppointments_View
as
with AppointmentData
as
(
	select 
		a.AppointmentID,
		CONCAT(doctorPerson.FirstName, ' ', doctorPerson.LastName, ' - ', s.Name) as DoctorFullLabel,
		CONCAT(patientPerson.FirstName, ' ', patientPerson.LastName) as PatientName,
		a.Date,
		StatusCaption = 
			case
				when a.Status = 1 Then 'Pending'
				when a.Status = 2 Then 'Confirmed'
				when a.Status = 3 Then 'Completed'
				when a.Status = 4 Then 'Cancelled'
				when a.Status = 5 Then 'Rescheduled'
				when a.Status = 6 Then 'NoShow'
			end,
		u.Username as ScheduledBy
	from Appointments a
		inner join Doctors d
			on a.DoctorID = d.DoctorID
		inner join Patients p
			on a.PatientID = p.PatientID
		inner join Persons doctorPerson
			on d.PersonID = doctorPerson.PersonID
		inner join Persons patientPerson
			on p.PersonID = patientPerson.PersonID
		inner join Specializations s
			on d.SpecializationID = s.SpecializationID
		inner join Users u
			on a.ScheduledBy = u.UserID
)
select AppointmentID, DoctorFullLabel, PatientName, Date, StatusCaption, ScheduledBy
from AppointmentData;