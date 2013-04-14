define(['jquery', 'text!../lib/excella/logErrorUrl.txt', 'toastr'], function (jQuery, logErrorUrl, toastr) {
        function logError(ex, toastrMsg, stack) {
            if (ex == null) return;
            if (logErrorUrl == null) {
                alert('logErrorUrl must be defined.');
                return;
            }
            
            if (toastrMsg != null) {
                toastr.error(toastrMsg + ex.message);
            }

            var url = ex.fileName != null ? ex.fileName : document.location;
            if (stack == null && ex.stack != null) stack = ex.stack;

            // format output
            var out = ex.message != null ? ex.name + ": " + ex.message : ex;

            out += ": at document path '" + url + "'.";
            if (stack != null) out += "\n  at " + stack.join("\n  at ");

            // send error message
            jQuery.ajax({
                type: 'POST',
                url: logErrorUrl,
                data: { message: out }
            });
        };

        Function.prototype.trace = function() {
            var trace = [];
            var current = this;
            while (current) {
                trace.push(current.signature());
                current = current.caller;
            }
            return trace;
        };

        Function.prototype.signature = function() {
            var signature = {
                name: this.getName(),
                params: [],
                toString: function() {
                    var params = this.params.length > 0 ?
                        "'" + this.params.join("', '") + "'" : "";
                    return this.name + "(" + params + ")"
                }
            };
            if (this.arguments) {
                for (var x = 0; x < this.arguments.length; x++)
                    signature.params.push(this.arguments[x]);
            }
            return signature;
        };

        Function.prototype.getName = function() {
            if (this.name)
                return this.name;
            var definition = this.toString().split("\n")[0];
            var exp = /^function ([^\s(]+).+/;
            if (exp.test(definition))
                return definition.split("\n")[0].replace(exp, "$1") || "anonymous";
            return "anonymous";
        };

        return {
          logError: logError  
        };
});