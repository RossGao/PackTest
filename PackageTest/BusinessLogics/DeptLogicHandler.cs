using EnterpriseOrganization.BusinessLogics;
using EnterpriseOrganization.Models;
using PackageTest.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UtilsPack.BusinessLogics;
using UtilsPack.Models;

namespace PackageTest.BusinessLogics
{
    public class DeptLogicHandler
    {
        private IOrgManager _OrgManager;
        private IChangeRecordManager _changeManager;

        public DeptLogicHandler(IOrgManager orgManager, IChangeRecordManager changeManager)
        {
            _OrgManager = orgManager;
            _changeManager = changeManager;
        }

        public Department UpdateDept(DeptDto dept, OperationTypeEnum operationType = OperationTypeEnum.Update)
        {
            if (dept != null)
            {
                return _OrgManager.UpdateDepartment(new Department
                {
                    Id = dept.Id,
                    Status = Enum.Parse<OrganizationStatusEnum>(dept.Status),
                    CompanyId = dept.CompanyId,
                    Description = dept.Description,
                    DirectorId = dept.DirectorId,
                    EmployeeIds = string.Join(',', dept.EmployeeIds),
                    Location = dept.Location,
                    Name = dept.Name,
                    ParentId = dept.ParentId,
                }, operationType: operationType);
            }

            return null;
        }

        public Department ConfirmChange(int changeId)
        {
            if (changeId != 0)
            {
                return _OrgManager.ImplementChange(changeId);
            }

            return null;
        }

        public ICollection<Department> GetDepts(DeptDto filters, int pageIndex = 1, int pageSize = 20)
        {
            return _OrgManager.GetDepartments(new Department
            {
                Code = filters.Code,
                CompanyId = filters.CompanyId,
                DirectorId = filters.DirectorId,
                EmployeeIds = string.Join(',', filters.EmployeeIds),
                Name = filters.Name,
                Location = filters.Location,
                ParentId = filters.ParentId,
                Id = filters.Id,
                Status = Enum.Parse<OrganizationStatusEnum>(filters.Status),
            }, pageIndex, pageSize);
        }

        public Department ActivateDept(int deptId)
        {
            return _OrgManager.ActivateDepartment(deptId);
        }

        public Department DeactivateDept(int deptId)
        {
            return _OrgManager.DeactivateDepartment(deptId);
        }

        public async Task<Department> RemoveEmployeesAsync(int deptId, ICollection<string> empIds)
        {
            if (empIds != null && empIds.Count > 0)
            {
                return await _OrgManager.RemoveEmployees(deptId, empIds);
            }

            return null;
        }

        public async Task<Department> AddEmployeesAsync(int deptId, ICollection<string> empIds)
        {
            if (deptId != 0 && empIds != null && empIds.Count > 0)
            {
                return await _OrgManager.AddEmployeesAsync(deptId, empIds);
            }

            return null;
        }

        public ChangeRecord DeleteChagne(int changeId)
        {
            if (changeId != 0)
            {
                return _changeManager.DeactivateRecord(changeId);
            }

            return null;
        }

        public ICollection<ChangeRecord> GetChanges(ChangeDto filter)
        {
            var query = new ChangeRecord
            {
                Id = filter.Id,
                ChangedProperties = filter.ChangedProperties,
                IsActive = filter.IsActive,
                SourceId = filter.SourceId,
            };

            Enum.TryParse(filter.OperationType, out OperationTypeEnum operationType);
            Enum.TryParse(filter.RecordType, out ChangeRecordTypeEnum recordType);
            query.OperationType = operationType;
            query.RecordType = recordType;

            return _changeManager.GetchangeRecords(query);
        }
    }
}
