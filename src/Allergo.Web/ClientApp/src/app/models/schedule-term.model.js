"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var ScheduleTerm = /** @class */ (function () {
    function ScheduleTerm(hour, minutes, isTaken, isTakenByCurrentUser, appointmentId) {
        this.hour = hour;
        this.minutes = minutes;
        this.isTaken = isTaken;
        this.isTakenByCurrentUser = isTakenByCurrentUser;
        this.appointmentId = appointmentId;
    }
    return ScheduleTerm;
}());
exports.ScheduleTerm = ScheduleTerm;
//# sourceMappingURL=schedule-term.model.js.map