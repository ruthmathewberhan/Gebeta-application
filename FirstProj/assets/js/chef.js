var ul = document.getElementById("dynamic_list");
var ingredient = document.getElementById("ingredient");
var quantity = document.getElementById("quantity");
var unit = document.getElementById("unit");
var add_btn = document.getElementById("add-btn");
console.log("simret");

var ul2 = document.getElementById("preparation_list");
var select = document.getElementById("select");
var steps = document.getElementById("steps");
var prep_btn = document.getElementById("prep_btn");

ul2.addEventListener("click", removeTask2);
prep_btn.addEventListener("click", addIngredient2);


ul.addEventListener("click", removeTask);
add_btn.addEventListener("click", addIngredient);

function addIngredient2(e) {
    console.log("sim");

    //var ingredient2 = document.getElementById("ingredient2");
    var li = document.createElement("li");
    //li.setAttribute('id',ingredient1.value);
    var input1 = document.createElement("input");
    input1.value = select.value;
    input1.name = "select";
    input1.classList.add("input1");
    input1.id = select.value;
    li.appendChild(input1);
    var input2 = document.createElement("input");
    input2.classList.add("input2");
    input2.name = "steps";
    
    input2.value = steps.value;
    input2.id = steps.value;
    li.appendChild(input2);

    //remove link
    const link = document.createElement("a");
    // Add class and the x marker for a
    link.className = "delete-item";
    link.classList.add("del-item");
    link.innerHTML = '<i style="color:red;" class="fa fa-remove ml-5 pl-5"></i>';

    li.appendChild(link);
    //li.appendChild(document.createTextNode(ingredient2.value));
    ul2.appendChild(li);
    select.value = "";
    steps.value = "";
}

// Remove Ingredient function definition
function removeTask2(e) {
    console.log("yep");
    if (e.target.parentElement.classList.contains("delete-item")) {
        console.log("yep del");
        if (confirm("Are You Sure about that ? ")) {
            e.target.parentElement.parentElement.remove();
        }
    }
}




function addIngredient(e) {
    console.log("HI");

    //var ingredient2 = document.getElementById("ingredient2");
    var li = document.createElement("li");
    //li.setAttribute('id',ingredient1.value);
    var input1 = document.createElement("input");
    input1.classList.add("inp1");
    input1.value = ingredient.value;
    input1.name = "ingredient";
    input1.id = ingredient.value;
    li.appendChild(input1);
    var input2 = document.createElement("input");
    input2.name = "quantity";
    input2.value = quantity.value;
    input2.id = quantity.value;
    li.appendChild(input2);
    var input3 = document.createElement("select");
    input3.classList.add("input3");
    var array = ["person", "people", "serving", "servings", "cup", "cups", "quart", "quarts", "gallon", "gallons", "dozen", "lbs", "bag", "bags", "liter", "liters"];
    for (var i = 0; i < array.length; i++) {
        var option = document.createElement("option");
        option.value = array[i];
        option.text = array[i];
        input3.id = array[i];
        input3.name = "unit";
        input3.appendChild(option);
    }
    var value1 = unit.value;
    var ops = input3.options;
    for (var opt, j = 0; opt = ops[j]; j++) {
        if (opt.value == value1) {
            input3.selectedIndex = j;
            break;
        }
    }

    li.appendChild(input3);

    //remove link
    const link = document.createElement("a");
    // Add class and the x marker for a
    link.className = "delete-item";
    link.innerHTML = '<i style="color:red;" class="fa fa-remove"></i>';

    li.appendChild(link);
    //li.appendChild(document.createTextNode(ingredient2.value));
    ul.appendChild(li);
    ingredient.value = "";
    quantity.value = "";
    unit.value = "";
}

// Remove Ingredient function definition
function removeTask(e) {
    console.log("yep");
    if (e.target.parentElement.classList.contains("delete-item")) {
        console.log("yep del");
        if (confirm("Are You Sure about that ? ")) {
            e.target.parentElement.parentElement.remove();
        }
    }
}