async function loadDoctors() {
    let search = document.getElementById("search").value;
    let specialty = document.getElementById("specialty").value;
    let sortord = document.getElementById("sortord").value;

    let params = new URLSearchParams({
        search: search,
        specialty: specialty,
        sortord: sortord
    });

    let response = await fetch("/Doctor/GetFilteredDoctors?" + params);
    let doctors = await response.json();

    let tbody = document.getElementById("doctorsTable");
    tbody.innerHTML = "";

    doctors.forEach(doctor => {
        let tr = document.createElement("tr");

        let properties = [
            doctor.firstName,
            doctor.lastName,
            doctor.specialty,
            doctor.hospitalName
        ];

        properties.forEach(prop => {
            let td = document.createElement("td");
            td.textContent = prop;
            tr.appendChild(td);
        });

        let actionsTd = document.createElement("td");
        let actions = ["Edit", "Details", "Delete"];

        actions.forEach((action, index) => {
            if (index > 0) {
                actionsTd.appendChild(document.createTextNode(" | "));
            }

            let link = document.createElement("a");
            link.href = `/Doctor/${action}/${doctor.id}`;
            link.textContent = action;
            actionsTd.appendChild(link);
        });

        tr.appendChild(actionsTd);
        tbody.appendChild(tr);
    });
}
document.getElementById("search").addEventListener("input", loadDoctors);
document.getElementById("specialty").addEventListener("input", loadDoctors);
document.getElementById("sortord").addEventListener("change", loadDoctors);
document.getElementById("clearFilters").addEventListener("click", () => {
    document.getElementById("search").value = "";
    document.getElementById("specialty").value = "";
    document.getElementById("sortord").value = "name_asc";
    loadDoctors();
});
