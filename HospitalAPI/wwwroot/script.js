const API_BASE = '/api';
let studiesDataTable, patientsDataTable, doctorsDataTable;
let patientsCache = [];
let doctorsCache = [];

$(document).ready(function () {
    studiesDataTable = $('#studiesTable').DataTable({
        ajax: {
            url: `${API_BASE}/Studies`,
            dataSrc: 'data'
        },
        columns: [
            { data: 'studyId' },
            { data: 'patientName' },
            { data: 'doctorName' },
            { data: 'modality' },
            {
                data: 'studyDate',
                render: function (data) {
                    return new Date(data).toLocaleDateString();
                }
            },
            {
                data: 'status',
                render: function (data) {
                    const badges = {
                        'Pending': 'bg-warning',
                        'In Progress': 'bg-info',
                        'Completed': 'bg-success',
                        'Cancelled': 'bg-secondary'
                    };
                    return `<span class="badge ${badges[data] || 'bg-secondary'}">${data}</span>`;
                }
            },
            {
                data: 'studyId',
                render: function (data, type, row) {
                    return `
                        <button class="btn btn-sm btn-outline-primary me-1" onclick="editStudy(${row.studyId})" title="Edit">
                            <i class="bi bi-pencil"></i>
                        </button>
                        <button class="btn btn-sm btn-outline-danger" onclick="deleteStudy(${row.studyId})" title="Delete">
                            <i class="bi bi-trash"></i>
                        </button>`;
                },
                orderable: false
            }
        ],
        order: [[4, 'desc']]
    });

    patientsDataTable = $('#patientsTable').DataTable({
        ajax: {
            url: `${API_BASE}/Patients`,
            dataSrc: function (json) {
                patientsCache = json.data || [];
                return json.data;
            }
        },
        columns: [
            { data: 'patientId' },
            { data: 'firstName' },
            { data: 'lastName' },
            {
                data: 'dateOfBirth',
                render: function (data) {
                    return new Date(data).toLocaleDateString();
                }
            },
            { data: 'gender' },
            { data: 'phone' },
            { data: 'email' },
            { data: 'mrn' },
            {
                data: 'status',
                render: function (data) {
                    const badges = {
                        'Active': 'bg-success',
                        'Inactive': 'bg-secondary',
                        'Discharged': 'bg-info'
                    };
                    return `<span class="badge ${badges[data] || 'bg-secondary'}">${data}</span>`;
                }
            },
            {
                data: 'patientId',
                render: function (data, type, row) {
                    return `
                        <button class="btn btn-sm btn-outline-primary me-1" onclick="editPatient(${row.patientId})" title="Edit">
                            <i class="bi bi-pencil"></i>
                        </button>
                        <button class="btn btn-sm btn-outline-danger" onclick="deletePatient(${row.patientId})" title="Delete">
                            <i class="bi bi-trash"></i>
                        </button>`;
                },
                orderable: false
            }
        ]
    });

    doctorsDataTable = $('#doctorsTable').DataTable({
        ajax: {
            url: `${API_BASE}/Doctors`,
            dataSrc: function (json) {
                doctorsCache = json.data || [];
                return json.data;
            }
        },
        columns: [
            { data: 'doctorId' },
            { data: 'firstName' },
            { data: 'lastName' },
            {
                data: 'dateOfBirth',
                render: function (data) {
                    return new Date(data).toLocaleDateString();
                }
            },
            { data: 'gender' },
            { data: 'phone' },
            { data: 'email' },
            { data: 'specialty' },
            {
                data: 'doctorId',
                render: function (data, type, row) {
                    return `
                        <button class="btn btn-sm btn-outline-primary me-1" onclick="editDoctor(${row.doctorId})" title="Edit">
                            <i class="bi bi-pencil"></i>
                        </button>
                        <button class="btn btn-sm btn-outline-danger" onclick="deleteDoctor(${row.doctorId})" title="Delete">
                            <i class="bi bi-trash"></i>
                        </button>`;
                },
                orderable: false
            }
        ]
    });

    $('#studyModal').on('show.bs.modal', loadDropdowns);
});

function loadDropdowns() {
    $.get(`${API_BASE}/Patients`, function (res) {
        const list = res.data || [];
        const select = $('#studyPatientId');
        select.empty().append('<option value="">Select Patient</option>');
        list.forEach(p => {
            select.append(`<option value="${p.patientId}">${p.firstName} ${p.lastName} (${p.mrn})</option>`);
        });
    });

    $.get(`${API_BASE}/Doctors`, function (res) {
        const list = res.data || [];
        const select = $('#studyDoctorId');
        select.empty().append('<option value="">Select Doctor</option>');
        list.forEach(d => {
            select.append(`<option value="${d.doctorId}">${d.firstName} ${d.lastName} - ${d.specialty}</option>`);
        });
    });
}

// Studies CRUD
function openStudyModal(study = null) {
    $('#studyId').val('');
    $('#studyPatientId').val('');
    $('#studyDoctorId').val('');
    $('#studyModality').val('');
    $('#studyDate').val(new Date().toISOString().split('T')[0]);
    $('#studyStatus').val('Pending');
    $('#studyModalTitle').text('Add PatientStudy');

    if (study) {
        $('#studyId').val(study.studyId);
        $('#studyPatientId').val(study.patientId);
        $('#studyDoctorId').val(study.doctorId);
        $('#studyModality').val(study.modality);
        $('#studyDate').val(study.studyDate.split('T')[0]);
        $('#studyStatus').val(study.status);
        $('#studyModalTitle').text('Edit PatientStudy');
    }

    new bootstrap.Modal('#studyModal').show();
}

function editStudy(id) {
    $.get(`${API_BASE}/Studies/${id}`, function (res) {
        if (res.success) openStudyModal(res.data);
    });
}

function saveStudy(e) {
    e.preventDefault();
    const id = $('#studyId').val();
    const payload = {
        patientId: parseInt($('#studyPatientId').val()),
        doctorId: parseInt($('#studyDoctorId').val()),
        modality: $('#studyModality').val(),
        studyDate: $('#studyDate').val(),
        status: $('#studyStatus').val()
    };

    const ajax = id
        ? $.ajax({ url: `${API_BASE}/Studies/${id}`, type: 'PUT', contentType: 'application/json', data: JSON.stringify(payload) })
        : $.ajax({ url: `${API_BASE}/Studies`, type: 'POST', contentType: 'application/json', data: JSON.stringify(payload) });

    ajax.done(function () {
        bootstrap.Modal.getInstance('#studyModal').hide();
        studiesDataTable.ajax.reload();
        showAlert(id ? 'Study updated successfully' : 'Study created successfully', 'success');
    }).fail(function (xhr) {
        showAlert('Error: ' + (xhr.responseJSON?.message || 'Unknown error'), 'danger');
    });
}

function deleteStudy(id) {
    if (!confirm('Are you sure you want to delete this study?')) return;
    $.ajax({
        url: `${API_BASE}/Studies/${id}`,
        type: 'DELETE'
    }).done(function () {
        studiesDataTable.ajax.reload();
        showAlert('Study deleted successfully', 'success');
    }).fail(function (xhr) {
        showAlert('Error: ' + (xhr.responseJSON?.message || 'Unknown error'), 'danger');
    });
}

// Patients CRUD
function openPatientModal(patient = null) {
    $('#patientId').val('');
    $('#patientFirstName').val('');
    $('#patientLastName').val('');
    $('#patientDOB').val('');
    $('#patientGender').val('');
    $('#patientPhone').val('');
    $('#patientEmail').val('');
    $('#patientMRN').val('');
    $('#patientStatus').val('Active');
    $('#patientModalTitle').text('Add Patient');

    if (patient) {
        $('#patientId').val(patient.patientId);
        $('#patientFirstName').val(patient.firstName);
        $('#patientLastName').val(patient.lastName);
        $('#patientDOB').val(patient.dateOfBirth.split('T')[0]);
        $('#patientGender').val(patient.gender);
        $('#patientPhone').val(patient.phone);
        $('#patientEmail').val(patient.email);
        $('#patientMRN').val(patient.mrn);
        $('#patientStatus').val(patient.status);
        $('#patientModalTitle').text('Edit Patient');
    }

    new bootstrap.Modal('#patientModal').show();
}

function editPatient(id) {
    $.get(`${API_BASE}/Patients/${id}`, function (res) {
        if (res.success) openPatientModal(res.data);
    });
}

function savePatient(e) {
    e.preventDefault();
    const id = $('#patientId').val();
    const payload = {
        firstName: $('#patientFirstName').val(),
        lastName: $('#patientLastName').val(),
        dateOfBirth: $('#patientDOB').val(),
        gender: $('#patientGender').val(),
        phone: $('#patientPhone').val(),
        email: $('#patientEmail').val(),
        mrn: $('#patientMRN').val(),
        status: $('#patientStatus').val()
    };

    const ajax = id
        ? $.ajax({ url: `${API_BASE}/Patients/${id}`, type: 'PUT', contentType: 'application/json', data: JSON.stringify(payload) })
        : $.ajax({ url: `${API_BASE}/Patients`, type: 'POST', contentType: 'application/json', data: JSON.stringify(payload) });

    ajax.done(function () {
        bootstrap.Modal.getInstance('#patientModal').hide();
        patientsDataTable.ajax.reload();
        showAlert(id ? 'Patient updated successfully' : 'Patient created successfully', 'success');
    }).fail(function (xhr) {
        showAlert('Error: ' + (xhr.responseJSON?.message || 'Unknown error'), 'danger');
    });
}

function deletePatient(id) {
    if (!confirm('Are you sure you want to delete this patient?')) return;
    $.ajax({
        url: `${API_BASE}/Patients/${id}`,
        type: 'DELETE'
    }).done(function () {
        patientsDataTable.ajax.reload();
        showAlert('Patient deleted successfully', 'success');
    }).fail(function (xhr) {
        showAlert('Error: ' + (xhr.responseJSON?.message || 'Unknown error'), 'danger');
    });
}

// Doctors CRUD
function openDoctorModal(doctor = null) {
    $('#doctorId').val('');
    $('#doctorFirstName').val('');
    $('#doctorLastName').val('');
    $('#doctorDOB').val('');
    $('#doctorGender').val('');
    $('#doctorPhone').val('');
    $('#doctorEmail').val('');
    $('#doctorSpecialty').val('');
    $('#doctorModalTitle').text('Add Doctor');

    if (doctor) {
        $('#doctorId').val(doctor.doctorId);
        $('#doctorFirstName').val(doctor.firstName);
        $('#doctorLastName').val(doctor.lastName);
        $('#doctorDOB').val(doctor.dateOfBirth.split('T')[0]);
        $('#doctorGender').val(doctor.gender);
        $('#doctorPhone').val(doctor.phone);
        $('#doctorEmail').val(doctor.email);
        $('#doctorSpecialty').val(doctor.specialty);
        $('#doctorModalTitle').text('Edit Doctor');
    }

    new bootstrap.Modal('#doctorModal').show();
}

function editDoctor(id) {
    $.get(`${API_BASE}/Doctors/${id}`, function (res) {
        if (res.success) openDoctorModal(res.data);
    });
}

function saveDoctor(e) {
    e.preventDefault();
    const id = $('#doctorId').val();
    const payload = {
        firstName: $('#doctorFirstName').val(),
        lastName: $('#doctorLastName').val(),
        dateOfBirth: $('#doctorDOB').val(),
        gender: $('#doctorGender').val(),
        phone: $('#doctorPhone').val(),
        email: $('#doctorEmail').val(),
        specialty: $('#doctorSpecialty').val()
    };

    const ajax = id
        ? $.ajax({ url: `${API_BASE}/Doctors/${id}`, type: 'PUT', contentType: 'application/json', data: JSON.stringify(payload) })
        : $.ajax({ url: `${API_BASE}/Doctors`, type: 'POST', contentType: 'application/json', data: JSON.stringify(payload) });

    ajax.done(function () {
        bootstrap.Modal.getInstance('#doctorModal').hide();
        doctorsDataTable.ajax.reload();
        showAlert(id ? 'Doctor updated successfully' : 'Doctor created successfully', 'success');
    }).fail(function (xhr) {
        showAlert('Error: ' + (xhr.responseJSON?.message || 'Unknown error'), 'danger');
    });
}

function deleteDoctor(id) {
    if (!confirm('Are you sure you want to delete this doctor?')) return;
    $.ajax({
        url: `${API_BASE}/Doctors/${id}`,
        type: 'DELETE'
    }).done(function () {
        doctorsDataTable.ajax.reload();
        showAlert('Doctor deleted successfully', 'success');
    }).fail(function (xhr) {
        showAlert('Error: ' + (xhr.responseJSON?.message || 'Unknown error'), 'danger');
    });
}

// Alert helper
function showAlert(message, type) {
    const alertHtml = `
        <div class="alert alert-${type} alert-dismissible fade show position-fixed top-0 end-0 m-3" style="z-index:9999" role="alert">
            ${message}
            <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
        </div>`;
    $('body').append(alertHtml);
    setTimeout(() => $('.alert').alert('close'), 3000);
}
