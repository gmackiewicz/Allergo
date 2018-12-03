export class DoctorUtil {
    getFullName = (doctor) => {
        if (!doctor || !doctor.firstName || !doctor.lastName) {
            return '';
        }
        return doctor.firstName + " " + doctor.lastName;
    }
}