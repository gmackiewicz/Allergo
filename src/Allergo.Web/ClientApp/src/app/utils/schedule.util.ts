export class ScheduleUtil {
    getDayName = (date) => {
        let id = new Date(date).getDay();

        if (id === 0) {
            return 'Niedziela';
        } else if (id === 1) {
            return 'Poniedziałek';
        } else if (id === 2) {
            return 'Wtorek';
        } else if (id === 3) {
            return 'Środa';
        } else if (id === 4) {
            return 'Czwartek';
        } else if (id === 5) {
            return 'Piątek';
        } else if (id === 6) {
            return 'Sobota';
        }
    };

    getClockFormat = (hour, minutes) => {
        return hour + ":" + (minutes === 0 ? "00" : minutes);
    }
}