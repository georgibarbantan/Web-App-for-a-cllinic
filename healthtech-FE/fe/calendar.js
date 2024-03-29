const daysTag = document.querySelector(".days"),
currentDate = document.querySelector(".current-date"),
prevNextIcon = document.querySelectorAll(".icons span");

// getting new date, current year and month
let date = new Date(),
currYear = date.getFullYear(),
currMonth = date.getMonth();

// storing full name of all months in array
const months = ["January", "February", "March", "April", "May", "June", "July",
              "August", "September", "October", "November", "December"];

const renderCalendar = () => {
    let firstDayofMonth = new Date(currYear, currMonth, 1).getDay(), // getting first day of month
    lastDateofMonth = new Date(currYear, currMonth + 1, 0).getDate(), // getting last date of month
    lastDayofMonth = new Date(currYear, currMonth, lastDateofMonth).getDay(), // getting last day of month
    lastDateofLastMonth = new Date(currYear, currMonth, 0).getDate(); // getting last date of previous month
    let liTag = "";

    for (let i = firstDayofMonth; i > 0; i--) {
        const prevMonthDate = new Date(currYear, currMonth, lastDateofLastMonth - i + 1);
        liTag += `<li class="inactive" data-date="${prevMonthDate.toISOString()}">${lastDateofLastMonth - i + 1}</li>`;
    }

    for (let i = 1; i <= lastDateofMonth; i++) {
        const currentDate = new Date(currYear, currMonth, i);
        let isToday = currentDate.toDateString() === date.toDateString() ? "active" : "";
        liTag += `<li class="${isToday}" data-date="${currentDate.toISOString()}">${i}</li>`;
    }

    for (let i = lastDayofMonth; i < 6; i++) {
        const nextMonthDate = new Date(currYear, currMonth + 1, i - lastDayofMonth + 1);
        liTag += `<li class="inactive" data-date="${nextMonthDate.toISOString()}">${i - lastDayofMonth + 1}</li>`;
    }
    currentDate.innerText = `${months[currMonth]} ${currYear}`; // passing current mon and yr as currentDate text
    daysTag.innerHTML = liTag;
}
renderCalendar();

prevNextIcon.forEach(icon => { // getting prev and next icons
    icon.addEventListener("click", () => { // adding click event on both icons
        // if clicked icon is previous icon then decrement current month by 1 else increment it by 1
        currMonth = icon.id === "prev" ? currMonth - 1 : currMonth + 1;

        if(currMonth < 0 || currMonth > 11) { // if current month is less than 0 or greater than 11
            // creating a new date of current year & month and pass it as date value
            date = new Date(currYear, currMonth, new Date().getDate());
            currYear = date.getFullYear(); // updating current year with new date year
            currMonth = date.getMonth(); // updating current month with new date month
        } else {
            date = new Date(); // pass the current date as date value
        }
        renderCalendar(); // calling renderCalendar function
    });
});

function markAppointmentDates(appointmentDates, specialityId) {
    appointmentDates.forEach((appointmentDate) => {
        // Check if appointmentDate is a valid Date object
        if (!(appointmentDate instanceof Date) || isNaN(appointmentDate.getTime())) {
            console.error('Invalid date:', appointmentDate);
            return;  // Skip invalid dates
        }

        console.group('Processing Date:', appointmentDate);

        try {
            const year = appointmentDate.getFullYear();
            const month = appointmentDate.getMonth() + 1;
            const day = appointmentDate.getDate();
            const formattedDate = `${year}-${month < 10 ? '0' + month : month}-${day < 10 ? '0' + day : day}T00:00:00.000Z`;

            console.log('Formatted Date:', formattedDate);

            const calendarDay = document.querySelector(`.calendar .days li[data-date="${formattedDate}"]`);

            console.log('Calendar Day Element:', calendarDay);

            if (calendarDay) {
                // Funcție pentru a obține specialityId în funcție de dată
                const specialityColor = SPECIALITY_COLORS[specialityId];

                calendarDay.style.borderBottom = `3px solid ${specialityColor}`;
                calendarDay.classList.add('appointment-day');
            }
        } catch (error) {
            console.error('Error processing date:', error.message);
        }

        console.groupEnd();
    });
}
