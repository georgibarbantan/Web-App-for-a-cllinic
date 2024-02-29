function displayAppointments(appointments) {
    const appointmentsContainer = document.querySelector('.appointments-container');
    appointmentsContainer.innerHTML = ''; // Clear existing content

    const calendarDays = document.querySelectorAll('.days li');

    appointments.forEach(appointment => {
        const appointmentItem = document.createElement('div');
        appointmentItem.classList.add('appointment-item');

        const titleElement = document.createElement('h3');
        titleElement.textContent = appointment.appointmentTitle; // Utilizează proprietatea reală a titlului programării
        appointmentItem.appendChild(titleElement);

        const dateElement = document.createElement('p');
        dateElement.textContent = `Date: ${appointment.appointmentDate}`; // Ajustează în funcție de structura răspunsului API-ului
        appointmentItem.appendChild(dateElement);

        const descriptionElement = document.createElement('p');
        descriptionElement.textContent = `Description: ${appointment.appointmentDescription}`; // Ajustează în funcție de structura răspunsului API-ului
        appointmentItem.appendChild(descriptionElement);

        // Adaugă stiluri pentru fiecare programare în funcție de culoarea asociată
        appointmentItem.style.borderColor = appointmentColors[appointment.appointmentType] || '#ccc';

        appointmentsContainer.appendChild(appointmentItem);

        // Subliniază ziua corespunzătoare în calendar
        const appointmentDate = new Date(appointment.appointmentDate);
        const dayToHighlight = appointmentDate.getDate();

        calendarDays.forEach(day => {
            const dayNumber = parseInt(day.textContent);
            if (dayNumber === dayToHighlight) {
                day.classList.add('highlighted-day');
            }
        });
    });
}

const appointmentColors = {
    'AppointmentType1': '#FF5733',  // Culoare pentru tipul de programare 1
    'AppointmentType2': '#33FF57',  // Culoare pentru tipul de programare 2
    // Adaugă culori suplimentare pentru alți tipi de programare
};

