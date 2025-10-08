using Microsoft.AspNetCore.Mvc;

namespace HR_Management.Presentation.Hatoeas;

public class LinkBuilder
{
    private readonly IUrlHelper _urlHelper;

    public LinkBuilder(IUrlHelper urlHelper)
    {
        _urlHelper = urlHelper;
    }

    //Links for get all
    public List<Link> BuildLinkForList(int id)
    {
        return new List<Link>
        {
            new Link { Href = _urlHelper.Action("Get", "LeaveType", new { id })!, Method = "GET", Rel= "Self"},
            new Link { Href= _urlHelper.Action("Get", "LeaveType")!, Method = "GET", Rel= "All" },
            new Link { Href= _urlHelper.Action("Post", "LeaveType")!, Method = "POST", Rel= "Create" },
            new Link { Href= _urlHelper.Action("Put", "LeaveType", new { id })!, Method = "PUT", Rel= "Update" },
            new Link { Href = _urlHelper.Action("Delete", "LeaveType", new { id })!, Method = "DELETE", Rel= "Delete" }
        };
    }

 
    //Links for get single item
    public List<Link> BuildLinkForItem(int id)
    {
        return new List<Link>
        {
            new Link { Href= _urlHelper.Action("Post", "LeaveType")!, Method = "POST", Rel= "Create" },
            new Link { Href= _urlHelper.Action("Put", "LeaveType", new { id })!, Method = "PUT", Rel= "Update" },
            new Link { Href = _urlHelper.Action("Delete", "LeaveType", new { id })!, Method = "DELETE", Rel= "Delete" }
        };
    }

    //Links for after create
    public List<Link> BuildLinkAfterCreate(int id)
    {
        return BuildLinkForItem(id);
    }

    //Links for after update
    public List<Link> BuildLinkAfterUpdate(int id)
    {
        return BuildLinkForItem(id);
    }

    //Links for after delete
    public List<Link> BuildLinkAfterDelete()
    {
        return new List<Link>
        {
            new Link { Href= _urlHelper.Action("Get", "LeaveType")!, Method = "GET", Rel= "All" },
            new Link { Href= _urlHelper.Action("Post", "LeaveType")!, Method = "POST", Rel= "Create" }
        };
    }
}
