$(document).ready(function () {
    $('#Cpf').mask('000.000.000-00', { reverse: true });

    var maskBehavior = function (val) {
        return val.replace(/\D/g, '').length === 11 ? '(00) 00000-0000' : '(00) 0000-00009';
    };

    var options = {
        onKeyPress: function (val, e, field, options) {
            field.mask(maskBehavior.apply({}, arguments), options);
        }
    };

    $('#Telefone').mask(maskBehavior, options);
   
  

});
