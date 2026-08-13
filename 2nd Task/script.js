let patients = [];

const form = document.getElementById('patientForm');
const nameInput = document.getElementById('name');
const ageInput = document.getElementById('age');
const genderInput = document.getElementById('gender');
const conditionInput = document.getElementById('condition');
const editIdInput = document.getElementById('editId');
const addBtn = document.getElementById('addBtn');
const updateBtn = document.getElementById('updateBtn');
const cancelBtn = document.getElementById('cancelBtn');
const formTitle = document.getElementById('formTitle');
const tbody = document.getElementById('patientTableBody');

function renderTable() {
  if (patients.length === 0) {
    tbody.innerHTML = `<tr><td colspan="6" class="text-center text-muted py-4">No patients registered yet.</td></tr>`;
    return;
  }
  tbody.innerHTML = patients.map(p => `
    <tr>
      <td class="fw-semibold">${p.id}</td>
      <td>${p.name}</td>
      <td>${p.age}</td>
      <td>${p.gender}</td>
      <td><span class="badge bg-info bg-opacity-10 text-info-emphasis px-3 py-2 rounded-pill">${p.condition}</span></td>
      <td class="text-center">
        <button class="btn btn-sm btn-outline-primary me-1" onclick="editPatient(${p.id})" title="Edit">
          <i class="bi bi-pencil-square"></i>
        </button>
        <button class="btn btn-sm btn-outline-danger" onclick="deletePatient(${p.id})" title="Delete">
          <i class="bi bi-trash3"></i>
        </button>
      </td>
    </tr>
  `).join('');
}

function resetForm() {
  form.reset();
  editIdInput.value = '';
  addBtn.classList.remove('d-none');
  updateBtn.classList.add('d-none');
  cancelBtn.classList.add('d-none');
  formTitle.textContent = 'Add Patient';
  document.querySelectorAll('.is-invalid').forEach(el => el.classList.remove('is-invalid'));
}

function getNextId() {
  return patients.length === 0 ? 1 : Math.max(...patients.map(p => p.id)) + 1;
}

form.addEventListener('submit', function (e) {
  e.preventDefault();

  if (!form.checkValidity()) {
    e.stopPropagation();
    form.classList.add('was-validated');
    return;
  }

  const patient = {
    name: nameInput.value.trim(),
    age: parseInt(ageInput.value),
    gender: genderInput.value,
    condition: conditionInput.value.trim(),
  };

  const editId = editIdInput.value;

  if (editId) {
    const idx = patients.findIndex(p => p.id === parseInt(editId));
    if (idx !== -1) {
      patients[idx] = { id: patients[idx].id, ...patient };
    }
  } else {
    patients.push({ id: getNextId(), ...patient });
  }

  resetForm();
  form.classList.remove('was-validated');
  renderTable();
});

window.editPatient = function (id) {
  const p = patients.find(pat => pat.id === id);
  if (!p) return;

  nameInput.value = p.name;
  ageInput.value = p.age;
  genderInput.value = p.gender;
  conditionInput.value = p.condition;
  editIdInput.value = p.id;

  addBtn.classList.add('d-none');
  updateBtn.classList.remove('d-none');
  cancelBtn.classList.remove('d-none');
  formTitle.textContent = 'Edit Patient';
};

updateBtn.addEventListener('click', function () {
  form.requestSubmit();
});

cancelBtn.addEventListener('click', resetForm);

window.deletePatient = function (id) {
  if (!confirm('Delete this patient record?')) return;
  patients = patients.filter(p => p.id !== id);
  renderTable();
  if (editIdInput.value == id) resetForm();
};
