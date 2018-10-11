<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="project.aspx.cs" Inherits="projectLinker.project" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="./jq/jquery-ui.min.css" rel="stylesheet"/>
    <link href="./jq/bootstrap.min.css" rel="stylesheet" />
    <link href="./jq/jq.grid.min.css" rel="stylesheet" />
    <script src="./js/jq.js" type="text/javascript"></script>
    <script src="./jq/jquery-ui.js" type="text/javascript"></script>
    <script src="./jq/jquery.jqgrid.min.js" type="text/javascript"></script>
    <script src="./js/script.js" type="text/javascript"></script>
     <script type="text/javascript">
         $(document).ready(function ()
         {
            showEntryPoint();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="showContent" title="View the page as" style=""display:none">
            <select id="ddlType" class="ui-selectable">
                <option value="1">Organisation</option>
                <option value="2">Contractor</option>
                <option value="3">Community</option>
            </select>
        </div>
        <table id="projects"></table>
    </form>
</body>
</html>
