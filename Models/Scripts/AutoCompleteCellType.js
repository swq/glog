
var ns = GcSpread.Sheets;
function AutoCompleteCellType(availableTags) {

    }

    AutoCompleteCellType.prototype = new ns.CustomCellType();

    AutoCompleteCellType.prototype.createEditorElement = function (context) {
        //Create input presenter.
        return document.createElement("input");
    };
    AutoCompleteCellType.prototype.activateEditor = function (editorContext, cellStyle, cellRect, context) {
        //Initialize input editor.
        if (editorContext) {
            $editor = $(editorContext);
            ns.CustomCellType.prototype.activateEditor.apply(this, arguments);
            $editor.autocomplete({ minLength: 0, source: availableTags });

            //$editor.datepicker();
            $editor.css("position", "absolute");
            $editor.attr("gcUIElement", "gcEditingInput");
            $(".ui-autocomplete").attr("gcUIElement", "gcEditingInput");

            //$editor.autocomplete("widget").attr("gcUIElement", "gcEditingInput");
        }
    }
    AutoCompleteCellType.prototype.deactivateEditor = function (editorContext, context) {
        //Remove input editor when end editor status.
        if (editorContext) {
            var element = editorContext;
            //$(element).datepicker("hide");
            //$(element).datepicker("destroy");
            $(element).autocomplete("destroy");
        }
        ns.CustomCellType.prototype.deactivateEditor.apply(this, arguments)
    };
    AutoCompleteCellType.prototype.setEditorValue = function (editor, value, context) {
        //Sync value from Cell value to editor value.
        //$(editor).datepicker("setDate", value);
        $(editor).val(value);
    };
    AutoCompleteCellType.prototype.getEditorValue = function (editor, context) {
        //Sync value from editor value to cell value.
        //return $(editor).datepicker("getDate");
        return $(editor).val();
    };
    AutoCompleteCellType.prototype.updateEditor = function (editorContext, cellStyle, cellRect, context) {
        if (editorContext) {
            $editor = $(editorContext);
            $editor.css("width", cellRect.width + 3);
            $editor.css("height", cellRect.height + 3);
        }
    };