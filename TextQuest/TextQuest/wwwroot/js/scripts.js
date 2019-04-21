
function scObjHandler(data_id, scene_id, inventory_id) {
    ShowDescription(data_id);
    console.log(data_id);
    console.log(scene_id);
    console.log(inventory_id);
    let selectedinventoryId;
    if ($(".inventoryObject").hasClass("selectedInventoryObject")) {
        selectedinventoryId = $(".selectedInventoryObject").attr("id");
    }
    console.log(selectedinventoryId);


    $.ajax({
        url: "/GamePage/HandleSceneObjectClick",
        type: "post",
        data: {
            item: String(data_id),
            scene: String(scene_id),
            inventory: String(inventory_id),
            selectedinventoryId: String(selectedinventoryId)
        },
        success: function (data) {
            console.log(data);
            if (data.interactionType == 0) {
                // Add item to inventory
                $(".inventory")
                    .append($("<div>").attr("id", String(data.responce.newId)).addClass("inventoryObject").attr("onmouseover", String("ShowInventoryDescription(" + data.responce.newId + ")")).attr("onclick", String("invObjHandler(" + data.responce.newId + ")")).attr("onmouseout", "RemoveText()").attr("title", String(data.responce.name))
                        .append($("<a>")
                            .append($("<img>").attr("src", data.responce.imageUrl))));
                $("#" + data.responce.oldId).remove();
                $(".inventoryObject").removeClass("selectedInventoryObject");
            }
            else if (data.interactionType == 1) {
                window.location.replace("@Url.RouteUrl(new { controller = "GamePage", action = "Index", id = Model.CurrentScene.InnerSceneId })");
            }
            else if (data.interactionType == 2) {
                if (data.responces.length > 0) {
                    if (data.responces[0].isValid) {
                        console.log("No");
                        return;
                    }
                    // Do set of animations
                    for (i = 0; i < data.responces.length; i++) {
                        $("#" + data.responces[i].oldId)
                            .replaceWith($("<div>").attr("id", String(data.responces[i].newId)).addClass("sceneObject").css("position", "absolute").css("left", data.responces[i].x).css("top", data.responces[i].y).attr("onmouseout", "RemoveText()")
                                .append($("<a>").attr("title", data.responces[i].Name) //todo: не ставится hover text
                                    .append($("<img>").attr("src", data.responces[i].imageUrl).attr("onclick", String("scObjHandler(" + data.responces[i].newId + ",@Model.CurrentScene.Id,@Model.Inventory.Id)")))));
                    }
                    $("div.selectedInventoryObject").remove()
                }

            }
        },
        error: function () {
            alert("error");
        }
    });
    RemoveText();

}
