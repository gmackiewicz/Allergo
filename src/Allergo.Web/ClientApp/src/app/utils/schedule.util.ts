import * as moment from 'moment';

export class ScheduleUtil {
    getDayName = (date) => {
        let id = new Date(date).getDay();

        return this.getDayNameById(id);
    };

    getDayNameById = (dayId) => {
        if (dayId === 0) {
            return 'Niedziela';
        } else if (dayId === 1) {
            return 'Poniedziałek';
        } else if (dayId === 2) {
            return 'Wtorek';
        } else if (dayId === 3) {
            return 'Środa';
        } else if (dayId === 4) {
            return 'Czwartek';
        } else if (dayId === 5) {
            return 'Piątek';
        } else if (dayId === 6) {
            return 'Sobota';
        }
    }

    getClockFormat = (hour, minutes) => {
        return hour + ":" + (minutes === 0 ? "00" : minutes);
    }

    formatTime = (time) => {
        return moment(time, 'HH:mm:ss').format('HH:mm');
    };
}