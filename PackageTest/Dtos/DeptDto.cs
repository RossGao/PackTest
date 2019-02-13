using System;
using System.Collections.Generic;

namespace PackageTest.Dtos
{
    /// <summary>
    /// 部门信息传输对象（这里与领域模型几乎一样，但实际项目中需要根据具体前端需求增加字段）
    /// </summary>
    public class DeptDto
    {
        /// <summary>
        /// 部门Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 部门编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 部门负责人Id
        /// </summary>
        public string DirectorId { get; set; }

        /// <summary>
        /// 部门简介
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 部门地址
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// 上级部门Id
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 部门员工Id列表, 以逗号分隔
        /// </summary>
        public ICollection<string> EmployeeIds { get; set; } = new List<string>();

        /// <summary>
        /// 部门所属公司
        /// </summary>
        public string CompanyId { get; set; }

        /// <summary>
        /// 部门状态（e.g. 待启用，生效，停用）
        /// </summary>
        public string Status { get; set; } = "默认";

        /// <summary>
        /// 变化记录Id
        /// </summary>
        public int changeId { get; set; }
    }
}
