using GSI_Internal.Entites;
using System.Collections.Generic;

namespace GSI_Internal.Repositry.RequirmentsFileAttachmentRepo
{
    public interface IRequirmentsFileAttachmentRepo
    {
        IEnumerable<RequirmentsFileAttachment> GetAll();

        RequirmentsFileAttachment GetByID(int Id);
        RequirmentsFileAttachment AddObj(RequirmentsFileAttachment obj);
        RequirmentsFileAttachment EditObj(RequirmentsFileAttachment obj);
        RequirmentsFileAttachment EditFile(RequirmentsFileAttachment obj);
        RequirmentsFileAttachment DeleteObj(int Id);
    }
}
