using EnterpriseOrganization.Models;
using UtilsPack.Models;

namespace PackageTest.Dtos
{
    public static class DtoTransfer
    {
        public static DeptDto ConvertDeptToDto(Department dept)
        {
            if (dept != null)
            {
                return new DeptDto
                {
                    Id = dept.Id,
                    Code = dept.Code,
                    CompanyId = dept.CompanyId,
                    CreateTime = dept.CreateTime,
                    Description = dept.Description,
                    DirectorId = dept.DirectorId,
                    EmployeeIds = dept.EmployeeIds.Split(','),
                    Location = dept.Location,
                    Name = dept.Name,
                    ParentId = dept.ParentId,
                    Status = dept.Status.ToString(),
                    UpdateTime = dept.UpdateTime,
                    changeId = dept.ActiveChangeId,
                };
            }

            return null;
        }

        public static ChangeDto ConvertChangeToDto(ChangeRecord change)
        {
            if (change != null)
            {
                var dto = new ChangeDto
                {
                    Id = change.Id,
                    ChangedProperties = change.ChangedProperties,
                    CreateTime = change.CreateTime,
                    IsActive = change.IsActive ?? false,
                    SourceId = change.SourceId,
                    UpdateTime = change.UpdateTime,
                    OperationType = change.OperationType.ToString(),
                    RecordType = change.RecordType.ToString(),
                };
            }

            return null;
        }
    }
}
