﻿<%@ Page Title="оферта" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="OfferEdit.aspx.cs" Inherits="IvanovWebsite.OfferEdit" %>
<%@ MasterType VirtualPath="~/Master.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/js/jquery-ui.min.js"></script>
    <script src="/js/numericInput.min.js"></script>    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<section id="form-container" class="container form">
    <h1><%=Master.PageTitle %></h1>
    <fieldset>
        <legend>НАЧАЛНА ДЕСТИНАЦИЯ</legend>
            
        <span class="row size1 align-middle">
            <label>От къде искате да тръгнете?</label>
            <asp:TextBox ID="FromLocationTextBox" runat="server" ClientIDMode="Static" MaxLength="50"></asp:TextBox>
        </span>
    </fieldset>
        
    <fieldset>
        <legend>КРАЙНА ДЕСТИНАЦИЯ</legend>
            
        <span class="row size1 align-middle">
            <label>До къде отивате?</label>
            <asp:TextBox ID="ToLocationTextBox" runat="server" ClientIDMode="Static" MaxLength="50"></asp:TextBox>
        </span>
    </fieldset>
    <fieldset>
        <legend>дати на пътуването</legend>
            
        <ul class="calendar col2 cl">
            <li>
                <label>Дата на тръгване</label>
                <div class="cal" id="from">
                </div>
                <asp:HiddenField ID="HFDateFrom" runat="server" ClientIDMode="Static" />
                <label>Мобилност при заминаването</label>
                <span class="row col2">
                    <span class="select">
                        <span></span>
                        <asp:DropDownList ID="FlexDaysStartBeforeCombo" runat="server" DataSourceID="FelxDaysBeforeDataSource" DataTextField="Caption" DataValueField="ID" ClientIDMode="Static"></asp:DropDownList>        
                    </span>
                    <span class="select">
                        <span></span>
                        <asp:DropDownList ID="FlexDaysStartAfterCombo" runat="server" DataSourceID="FelxDaysAfterDataSource" DataTextField="Caption" DataValueField="ID" ClientIDMode="Static"></asp:DropDownList>
                    </span>
                </span>
                <span class="radio">
                    <label>
                        <asp:RadioButton ID="IsOneWayRadio" runat="server" ClientIDMode="Static" GroupName="Ways" />
                        <span>Еднопосочен</span>
                    </label>
                </span>
            </li>
            <li id="TwoWayLi">
                <label>Дата на връщане</label>
                <div class="cal" id="to">
                </div>
                <asp:HiddenField ID="HFDateTo" runat="server" ClientIDMode="Static" />
                <label>Мобилност при връщането</label>
                <span class="row col2">
                    <span class="select">
                        <span></span>
                        <asp:DropDownList ID="FlexDaysEndBeforeCombo" runat="server" DataSourceID="FelxDaysBeforeDataSource" DataTextField="Caption" DataValueField="ID" ClientIDMode="Static"></asp:DropDownList>
                    </span>
                    <span class="select">
                        <span></span>
                        <asp:DropDownList ID="FlexDaysEndAfterCombo" runat="server" DataSourceID="FelxDaysAfterDataSource" DataTextField="Caption" DataValueField="ID" ClientIDMode="Static"></asp:DropDownList>
                    </span>
                </span>
                    
                <span class="radio">
                    <label>
                        <asp:RadioButton ID="IsTwoWayRadio" runat="server" ClientIDMode="Static" GroupName="Ways" />
                        <span>Двупосочен</span>
                    </label>
                </span>
            </li>
        </ul>
    </fieldset>
    <asp:ObjectDataSource ID="FelxDaysBeforeDataSource" runat="server" TypeName="Core.DictionaryRepository" SelectMethod="ListDictionary" CacheDuration="3600">
        <SelectParameters>
            <asp:Parameter Name="Level" Type="Int32" DefaultValue="1" />
            <asp:Parameter Name="DictionaryCode" Type="Int32" DefaultValue="10" />
            <asp:Parameter Name="IsVisible" Type="Boolean" />
            <asp:Parameter Name="WithNullValue" Type="Boolean" DefaultValue="True" />
            <asp:Parameter Name="NullValueText" Type="String" DefaultValue="None Before" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="FelxDaysAfterDataSource" runat="server" TypeName="Core.DictionaryRepository" SelectMethod="ListDictionary" CacheDuration="3600">
        <SelectParameters>
            <asp:Parameter Name="Level" Type="Int32" DefaultValue="1" />
            <asp:Parameter Name="DictionaryCode" Type="Int32" DefaultValue="11" />
            <asp:Parameter Name="IsVisible" Type="Boolean" />
            <asp:Parameter Name="WithNullValue" Type="Boolean" DefaultValue="True" />
            <asp:Parameter Name="NullValueText" Type="String" DefaultValue="None After" />
        </SelectParameters>
    </asp:ObjectDataSource>
        
    <fieldset>
        <legend>брой на пътуващите</legend>
            
        <span class="row radio-icon people">
            <label data-show="single">
                <asp:RadioButton ID="AloneRadio" runat="server" GroupName="PeopleGroup" />
                <span><img src="/images/icons/form/single.png" alt="" /></span>
                <b>Самостоятелно</b>
            </label>
            <label data-show="single">
                <asp:RadioButton ID="CoupleRadio" runat="server" GroupName="PeopleGroup" />
                <span><img src="/images/icons/form/couple.png" alt="" /></span>
                <b>Двойка</b>
            </label>
            <label data-show="family">
                <asp:RadioButton ID="FamilyRadio" runat="server" GroupName="PeopleGroup" />
                <span><img src="/images/icons/form/family.png" alt="" /></span>
                <b>Семейство</b>
            </label>
            <label data-show="family">
                <asp:RadioButton ID="PeopleGroupRadio" runat="server" GroupName="PeopleGroup" />
                <span><img src="/images/icons/form/group.png" alt="" /></span>
                <b>Група</b>
            </label>
        </span>
    </fieldset>
        
    <div class="sl-toggle">
        <i></i>
        <div class="align-middle">
            <span class="single family">
                <span class="select">
                    <span></span>
                        <asp:DropDownList ID="AdultsCountCombo" runat="server" ClientIDMode="Static">
                        <asp:ListItem Text="0" Value="0"></asp:ListItem>
                        <asp:ListItem Text="1" Value="1"></asp:ListItem>
                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                        <asp:ListItem Text="6" Value="6"></asp:ListItem>
                        <asp:ListItem Text="7" Value="7"></asp:ListItem>
                        <asp:ListItem Text="8" Value="8"></asp:ListItem>
                        <asp:ListItem Text="9" Value="9"></asp:ListItem>
                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                    </asp:DropDownList>
                </span>
                <label>Възрастни</label>
            </span>
                
            <span class="family">
                <span class="select">
                    <span></span>
                        <asp:DropDownList ID="ChildrenCountCombo" runat="server" ClientIDMode="Static">
                        <asp:ListItem Text="0" Value="0"></asp:ListItem>
                        <asp:ListItem Text="1" Value="1"></asp:ListItem>
                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                        <asp:ListItem Text="6" Value="6"></asp:ListItem>
                        <asp:ListItem Text="7" Value="7"></asp:ListItem>
                        <asp:ListItem Text="8" Value="8"></asp:ListItem>
                        <asp:ListItem Text="9" Value="9"></asp:ListItem>
                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                    </asp:DropDownList>
                </span>
                <label>Деца до 12г</label>
            </span>
                
            <span class="single family">
                <span class="select">
                    <span></span>
                        <asp:DropDownList ID="LuggageCountCombo" runat="server" ClientIDMode="Static">
                        <asp:ListItem Text="0" Value="0"></asp:ListItem>
                        <asp:ListItem Text="1" Value="1"></asp:ListItem>
                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                        <asp:ListItem Text="6" Value="6"></asp:ListItem>
                        <asp:ListItem Text="7" Value="7"></asp:ListItem>
                        <asp:ListItem Text="8" Value="8"></asp:ListItem>
                        <asp:ListItem Text="9" Value="9"></asp:ListItem>
                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                    </asp:DropDownList>
                </span>
                <label><img src="/images/icons/form/bags.png" /></label>
            </span>
                
            <span class="single family">
                <span class="select">
                    <span></span>
                        <asp:DropDownList ID="StudentsCountCombo" runat="server" ClientIDMode="Static">
                        <asp:ListItem Text="0" Value="0"></asp:ListItem>
                        <asp:ListItem Text="1" Value="1"></asp:ListItem>
                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                        <asp:ListItem Text="6" Value="6"></asp:ListItem>
                        <asp:ListItem Text="7" Value="7"></asp:ListItem>
                        <asp:ListItem Text="8" Value="8"></asp:ListItem>
                        <asp:ListItem Text="9" Value="9"></asp:ListItem>
                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                    </asp:DropDownList>
                </span>
                <label>Студенти</label>
            </span>
                
            <span class="family">
                <span class="select">
                    <span></span>
                        <asp:DropDownList ID="InfantCountCombo" runat="server" ClientIDMode="Static">
                        <asp:ListItem Text="0" Value="0"></asp:ListItem>
                        <asp:ListItem Text="1" Value="1"></asp:ListItem>
                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                        <asp:ListItem Text="6" Value="6"></asp:ListItem>
                        <asp:ListItem Text="7" Value="7"></asp:ListItem>
                        <asp:ListItem Text="8" Value="8"></asp:ListItem>
                        <asp:ListItem Text="9" Value="9"></asp:ListItem>
                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                    </asp:DropDownList>
                </span>
                <label>Бебета до 2г</label>
            </span>
        </div>
    </div>

    
        
    <fieldset>
        <legend>транспорт</legend>
        <span class="row checkbox">
            <span class="label">Моля изберете желаните от вас начини за транспорт</span>
                
            <span class="input">
                <label class="clear">
                    <input type="checkbox" />
                    <span>Не желая</span>
                </label>
            </span>
        </span>
            
        <span class="row radio-icon">
            <label>                                    	
                <asp:CheckBox ID="TransportPlaneCheckbox" runat="server" />
                <span><img src="/images/icons/form/plane.png" alt="" /></span>
                <b>Самолет</b>
            </label>
            <label>                	
                <asp:CheckBox ID="TransportTrainCheckbox" runat="server" />
                <span><img src="/images/icons/form/train.png" alt="" /></span>
                <b>Влак</b>
            </label>
            <label>                	
                <asp:CheckBox ID="TransportBusCheckbox" runat="server" />
                <span><img src="/images/icons/form/bus.png" alt="" /></span>
                <b>Автобус</b>
            </label>
            <label>                	
                <asp:CheckBox ID="TransportFerryCheckbox" runat="server" />
                <span><img src="/images/icons/form/ferry.png" alt="" /></span>
                <b>Ферибот</b>
            </label>
        </span>
        <asp:PlaceHolder ID="TransportPricePlaceHolder" runat="server">
        <span class="row size1 align-middle">
            <label>От къде е получена цената?</label>
            <asp:TextBox ID="TransportPriceRefererTextBox" runat="server" MaxLength="100"></asp:TextBox>                
        </span>
        </asp:PlaceHolder>
    </fieldset>
        
    <fieldset>
        <legend>нощувки</legend>
        <span class="row checkbox">
            <span class="label">Моля изберете желаните от вас начини за нощуване</span>                                
        </span>
            
        <span class="row fw">
            <span class="row radio-icon">
                <label>                        
                    <asp:CheckBox ID="CampingCheckBox" runat="server" />
                    <span><img src="/images/icons/form/camping.png" alt="" /></span>
                    <b>Къмпинг</b>
                </label>
                <label>
                    <asp:CheckBox ID="HostelCheckBox" runat="server" />
                    <span><img src="/images/icons/form/hostel.png" alt="" /></span>
                    <b>Хостел</b>
                </label>
                <label>
                    <asp:CheckBox ID="Hotel23CheckBox" runat="server" />
                    <span><img src="/images/icons/form/hotel_23.png" alt="" /></span>
                    <b>Хотел</b>
                </label>
                <label>
                    <asp:CheckBox ID="Hotel45CheckBox" runat="server" />
                    <span><img src="/images/icons/form/hotel_45.png" alt="" /></span>
                    <b>Хотел</b>
                </label>
                <label>
                    <asp:CheckBox ID="ApartmentCheckBox" runat="server" />
                    <span><img src="/images/icons/form/apartment.png" alt="" /></span>
                    <b>Студио <br />Апартамент</b>
                </label>
            </span>
        </span>
            
        <span class="row size1 align-middle">
            <label>От къде е получена цената?</label>
            <asp:TextBox ID="RefererWebsiteTextBox" runat="server" MaxLength="100"></asp:TextBox>                
        </span>            
    </fieldset>
        
    <fieldset>
        <legend>ТРАНСПОРТ ПО ВРЕМЕ НА ПРЕСТОЯ</legend>
            
        <span class="row radio">
            <span class="label">Желаете ли да използвате кола под наем?</span>
                
            <span class="input">
                <label>
                    <asp:RadioButton ID="CarRentYesRadio" runat="server" ClientIDMode="Static" GroupName="CarRent" />                        
                    <span>Да</span>
                </label>
                <label>
                    <asp:RadioButton ID="CarRentNoRadio" runat="server" ClientIDMode="Static" GroupName="CarRent" />
                    <span>Не</span>
                </label>
            </span>
        </span>
        <span id="CarRentCompanySpan" class="row size1 align-middle">
            <label>Имате ли предпочитана рент-а-кар компания?</label>
            <asp:TextBox ID="CarRentCompanyTextBox" runat="server" ClientIDMode="Static" MaxLength="100"></asp:TextBox>                
        </span>
    </fieldset>     
        
    <fieldset>
        <legend>БЮДЖЕТ</legend>
            
        <span class="row col2">         
            <span>
                <label>Стойност на получената оферта</label>
                <span class="price">
                    <asp:TextBox ID="MaxPriceTextBox" runat="server" ClientIDMode="Static"></asp:TextBox>
                    <span class="select">
                        <span></span>
                        <asp:DropDownList ID="CurrenciesMaxPriceCombo" runat="server" DataSourceID="CurrenciesDataSource" DataTextField="Caption" DataValueField="ID" ClientIDMode="Static"></asp:DropDownList>
                    </span>
                </span>
            </span>            
        </span>
    </fieldset>
    <asp:ObjectDataSource ID="CurrenciesDataSource" runat="server" TypeName="Core.DictionaryRepository" SelectMethod="ListDictionary" CacheDuration="3600">
        <SelectParameters>
            <asp:Parameter Name="Level" Type="Int32" DefaultValue="1" />
            <asp:Parameter Name="DictionaryCode" Type="Int32" DefaultValue="6" />
            <asp:Parameter Name="IsVisible" Type="Boolean" />                
        </SelectParameters>
    </asp:ObjectDataSource>
    <fieldset>
        <legend>данни за връзка</legend>
            
        <span class="row col2 align-middle">
            <span>
                <label>Име</label>
                <asp:TextBox ID="FnameTextBox" runat="server" MaxLength="20" ClientIDMode="Static"></asp:TextBox>
            </span>          	
            <span>
                <label>Фамилия</label>
                <asp:TextBox ID="LnameTextBox" runat="server" MaxLength="20" ClientIDMode="Static"></asp:TextBox>
            </span>
        </span>
            
        <span class="row col2 align-middle">
            <span>
                <label>Ел.поща</label>
                <asp:TextBox ID="EmailTextBox" runat="server" MaxLength="100" ClientIDMode="Static"></asp:TextBox>
            </span>          	
            <span>
                <label>Националност</label>
                <span class="select">
                    <span></span>
                    <asp:DropDownList ID="NationalityCombo" runat="server" DataSourceID="NationalityDataSource" DataTextField="Caption" DataValueField="ID" ClientIDMode="Static"></asp:DropDownList>
                    <asp:ObjectDataSource ID="NationalityDataSource" runat="server" TypeName="Core.DictionaryRepository" SelectMethod="ListDictionary" CacheDuration="3600">
                        <SelectParameters>
                            <asp:Parameter Name="Level" Type="Int32" DefaultValue="1" />
                            <asp:Parameter Name="DictionaryCode" Type="Int32" DefaultValue="5" />
                            <asp:Parameter Name="IsVisible" Type="Boolean" />
                            <asp:Parameter Name="WithNullValue" Type="Boolean" DefaultValue="True" />
                            <asp:Parameter Name="NullValueText" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </span>
            </span>
        </span>
    </fieldset>
        
    <fieldset>
        <legend>ВРЕМЕ ЗА ОТГОВОР</legend>
            
        <span class="row size2 align-middle">
            <label>Колкото повече време ни предоставите за отговор, толкова по-добра оферта ще ви предоставим.</label>
            <span class="select">
                <span></span>
                <asp:DropDownList ID="ResearchTimeCombo" runat="server" DataSourceID="ResearchTimeDataSource" DataTextField="Caption" DataValueField="ID" ClientIDMode="Static"></asp:DropDownList>
                    <asp:ObjectDataSource ID="ResearchTimeDataSource" runat="server" TypeName="Core.DictionaryRepository" SelectMethod="ListDictionary" CacheDuration="3600">
                        <SelectParameters>
                            <asp:Parameter Name="Level" Type="Int32" DefaultValue="1" />
                            <asp:Parameter Name="DictionaryCode" Type="Int32" DefaultValue="8" />
                            <asp:Parameter Name="IsVisible" Type="Boolean" />                                
                        </SelectParameters>
                    </asp:ObjectDataSource>
            </span>
        </span>
    </fieldset>
        
        
    <fieldset>
        <legend>ДОПЪЛНИТЕЛНА ИНФОРМАЦИЯ</legend>
            
        <p>Моля да ни предоставите повече информация за вашето пътуване - какво искате да правите? Искате да посетите определени места? Искате или не искате да използвате дадена авиокомпания? Въобще всичко, което може да ни помогне да направим по-доброто предложение</p>            
        <span class="row">
            <asp:TextBox ID="AddInfoTextBox" runat="server" ClientIDMode="Static" TextMode="MultiLine" Rows="5" placeholder="Please tell us anything extra you would like to add.."></asp:TextBox>            	
        </span>
            
        <span class="row checkbox list">                
            <label>
                <asp:CheckBox ID="ReceiveNewslettersCheckBox" runat="server" ClientIDMode="Static" />
                <span>
                    You would like to recieve our newsletter and information coming from us and our partner.
                </span>
            </label>
            <label>
                <asp:CheckBox ID="ReceiveCommercialInfoCheckbox" runat="server" ClientIDMode="Static" />
                <span>
                    The information collected above is necessary for Darjeelin to deal with your demand. It is
saved in our customer database. We remind you that you have the right of access, rectification, and cancellation of your details, according to the Data Protection Act of January 6, 1978. If you wish to recieve commercial information by email from our partners, please check this box.
				</span>
            </label>
            <label>
                <asp:CheckBox ID="AgreeTermsOfUseCheckbox" runat="server" ClientIDMode="Static" Checked="true" />
                <span>
                    By ticking this box, you agree to the <a href="#">terms and conditions</a> of Darjeelin.
For more information regarding our privacy policy, please click <a href="#">here</a>.
                </span>
            </label>
        </span>
    </fieldset>
        
    <p>
        <a href="/" class="btn magenta stop">Отказ</a>
        <asp:LinkButton ID="SaveButton" runat="server" CssClass="btn blue" Text="Следваща стъпка" OnClick="SaveButton_Click"></asp:LinkButton>        	
    </p>
</section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsPlaceHolder" runat="server">

<asp:PlaceHolder ID="FormScriptsPlaceHolder" runat="server">
<script>
    $(function () {
        //form ---------

        //select
        $("span.select").each(function () {
            var Text = $(this).children("select").children("option:selected").text()
            Text = Text.length > 15 ? Text.substring(0, 12) + " ..." : Text;
            $(this).children("span").text(Text);
        });

        $("span.select select").change(function () {
            var Text = $(this).children("option:selected").text();
            Text = Text.length > 15 ? Text.substring(0, 12) + " ..." : Text;
            $(this).parent().children("span").text(Text);            
        });

        $(".radio-icon label").on("click", function () {
            var checked = $(this).children().prop('checked');
            if (checked) {
                $(this).closest('fieldset').find('.clear input').removeAttr('checked');
            }
        });

        $("label.clear").on("click", function () {
            var checked = $(this).children().prop('checked');
            if (!checked) {
                $(this).closest('fieldset').find('.radio-icon input').removeAttr('checked');
            }
        });



        //on load
        var inputChecked = $(".radio-icon.people input:checked").parent();
        $('.sl-toggle > i').css({ left: inputChecked.position().left + 52 });
        var target = inputChecked.attr('data-show');
        $('.sl-toggle').attr('data-target', target);

        //on click
        $(".radio-icon.people label").click(function () {
            var checked = $(this).children().is(':checked');
            if (checked) {

                var target = $(this).attr('data-show');
                if (target) {
                    $('.sl-toggle > i').css({ left: $(this).position().left + 52 })
                }

                $('.sl-toggle').removeAttr('data-target');
                $('.sl-toggle').attr('data-target', target);
            }
        });

        

        $("#from").datepicker({
            dateFormat: 'M d, yy',
            onSelect: function (dateText) {                
                $("#HFDateFrom").val(dateText);
            }
        });
        
        $("#to").datepicker({
            dateFormat: 'M d, yy',
            onSelect: function (dateText) {                                
                $("#HFDateTo").val(dateText);
            }
        });

        $("#from").datepicker("setDate", $("#HFDateFrom").val());
        $("#to").datepicker("setDate", $("#HFDateTo").val());
        

        $("#MaxPriceTextBox,#MaxPricePerPersonTextBox").numericInput({ allowNegative: false, allowFloat: false });

        if ($("#IsOneWayRadio").is(":checked")) {            
            InitOneWay();
        }

        $("#IsOneWayRadio").click(function () {            
            InitOneWay();
        });

        $("#IsTwoWayRadio").click(function () {
            InitTwoWay();
        });

        $("#CarRentYesRadio").click(function () {
            $("#CarRentCompanySpan").slideDown(100);
        });
        $("#CarRentNoRadio").click(function () {
            $("#CarRentCompanySpan").slideUp(100);
        });
    });

    function InitOneWay() {
        $("#TwoWayLi #to").datepicker("option", "disabled", true);
        $("#TwoWayLi select").attr("disabled", "disabled");
        $("#TwoWayLi #to").addClass("disabled");
        $("#TwoWayLi .row.col2").addClass("disabled");
    }

    function InitTwoWay() {
        $("#to").datepicker("option", "disabled", false);
        $("#TwoWayLi select").removeAttr("disabled", "disabled");
        $("#to").removeClass("disabled");
        $("#TwoWayLi .row.col2").removeClass("disabled");
    }
</script>
</asp:PlaceHolder>

<asp:PlaceHolder ID="ErrorPlaceHolder" runat="server" ViewStateMode="Disabled" Visible="false">
<script>alert("<%=Core.Properties.Resources.Abort%>");</script>
</asp:PlaceHolder>

<asp:PlaceHolder ID="AgreeToTermsPlaceHolder" runat="server" ViewStateMode="Disabled" Visible="false">
<script>alert("<%=Core.Properties.Resources.InformationAgreeToTerms%>");</script>
</asp:PlaceHolder>

<asp:PlaceHolder ID="AllRequiredPlaceHolder" runat="server" ViewStateMode="Disabled" Visible="false">
<script>alert("<%=Core.Properties.Resources.InformationAllFieldsAreRequired%>");</script>
</asp:PlaceHolder>
<asp:PlaceHolder ID="EnvalidEmailPlaceHolder" runat="server" ViewStateMode="Disabled" Visible="false">
<script>alert("<%=Core.Properties.Resources.InformationInvalidEmailAddress%>");</script>
</asp:PlaceHolder>
</asp:Content>
