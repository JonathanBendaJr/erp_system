    function setttData(id) {
        window.location.href = '/Employee/EmployeeEducation/AddEmployeeEducation/' + id;
};
function deptData(id) {
    window.location.href = '/Employee/EmployeeEducation/AddEmployeeEducation/' + id;
};

function depttData(id) {
    window.location.href = '/Employee/EmployeeDepartment/AddEmployeeDepartment/' + id;

        //window.location.href = '/Employee/EmployeeAdditionalInformation/GetEducationListByEmpId/' + id;
    };

    function setWorkData(id) {
        window.location.href = '/Employee/EmployeeWork/AddEmployeeWork/' + id;

        //window.location.href = '/Employee/EmployeeAdditionalInformation/GetEducationListByEmpId/' + id;
    };

    function setSalaryData(id) {
        window.location.href = '/Employee/EmployeeSalary/AddEmployeeSalary/' + id;

        //window.location.href = '/Employee/EmployeeAdditionalInformation/GetEducationListByEmpId/' + id;
    };

    function setDependantsData(id) {
        window.location.href = '/Employee/EmployeeDependant/AddEmployeeDependant/' + id;

        //window.location.href = '/Employee/EmployeeAdditionalInformation/GetEducationListByEmpId/' + id;
    };

   
function loadData(id) {
    // window.location.href = '/Employee/EmployeeAdditionalInformation/AddEmployeeEducation/' + id;
    $("#btnLoadPartial").click(function () {
        window.location.href = '/Employee/EmployeeEducation/GetEducationListByEmpId/' + id,
        $.ajax({
            type: 'GET',
            success: function (result) {
                $('#targetDiv').html(result);
            }
        });
    });
};

    