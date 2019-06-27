function reloadItems() {
    $("#btnClear").click();

    let domToAdd = `<div class="whatsNewSideBarItem">
            <div class="sideBarCard">
                <div class="sideBarCardHeader">
                    <div class="sideBarCardDate">Thursday, 20th August 2019</div>
                    <div class="sideBarCardCloseButton" title="Remove this item"></div>
                </div>
                <div class="sideBarCardBody">
                    <div class="sideBarCardText">
                        Ting Tong went away.
                    </div>
                </div>
            </div>
        </div>
        
        <div class="whatsNewSideBarItem">
            <div class="sideBarCard">
                <div class="sideBarCardHeader">
                    <div class="sideBarCardDate">Monday, 1st August 2019</div>
                    <div class="sideBarCardCloseButton" title="Remove this item"></div>
                </div>
                <div class="sideBarCardBody">
                    <div class="sideBarCardText">
                        Ting Tong visited us and gave us a lecture.
                    </div>
                </div>
            </div>
        </div>
        
        <div class="whatsNewSideBarItem">
            <div class="sideBarCard">
                <div class="sideBarCardHeader">
                    <div class="sideBarCardDate">Thursday, 20th July 2019</div>
                    <div class="sideBarCardCloseButton" title="Remove this item"></div>
                </div>
                <div class="sideBarCardBody">
                    <div class="sideBarCardText">
                        Ting Tong came back.
                    </div>
                </div>
            </div>
        </div>

        <div class="whatsNewSideBarItem">
            <div class="sideBarCard">
                <div class="sideBarCardHeader">
                    <div class="sideBarCardDate">Tuesday, 2nd August 2019</div>
                    <div class="sideBarCardCloseButton" title="Remove this item"></div>
                </div>
                <div class="sideBarCardBody">
                    <div class="sideBarCardText">
                        Ting Tong went away again.
                    </div>
                </div>
            </div>
        </div>

        <div class="whatsNewSideBarItem">
            <div class="sideBarCard">
                <div class="sideBarCardHeader">
                    <div class="sideBarCardDate">Saturday, 1st September 2019</div>
                    <div class="sideBarCardCloseButton" title="Remove this item"></div>
                </div>
                <div class="sideBarCardBody">
                    <div class="sideBarCardText">
                        Ting Tong came back again.
                    </div>
                </div>
            </div>
        </div>

        <div class="whatsNewSideBarItem">
            <div class="sideBarCard">
                <div class="sideBarCardHeader">
                    <div class="sideBarCardDate">Sunday, 2nd September 2019</div>
                    <div class="sideBarCardCloseButton" title="Remove this item"></div>
                </div>
                <div class="sideBarCardBody">
                    <div class="sideBarCardText">
                        Ting Tong said ting tong ting tong ting tong ting tong.
                    </div>
                </div>
            </div>
        </div>

        <div class="whatsNewSideBarItem">
            <div class="sideBarCard">
                <div class="sideBarCardHeader">
                    <div class="sideBarCardDate">Sunday, 2nd September 2019</div>
                    <div class="sideBarCardCloseButton" title="Remove this item"></div>
                </div>
                <div class="sideBarCardBody">
                    <div class="sideBarCardText">
                        Ting Tong did not go away.
                    </div>
                </div>
            </div>
        </div>`;

    $("#whatsNewSideBarBody").append(domToAdd);
}

$(document).ready(function() {
    $("#btnClear").click(event => $(".whatsNewSideBarItem").remove());
    $("#btnReload").click(event => reloadItems());
});