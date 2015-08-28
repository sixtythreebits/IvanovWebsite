<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OfferPage.aspx.cs" Inherits="IvanovWebsite.admin.OfferPage1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <link rel="stylesheet" type="text/css" href="/css/fonts.css" />    
    <link href="/css/style.css" rel="stylesheet" />
    <script src="/js/jquery-2.1.3.min.js"></script>
    <script src="/js/jquery-ui.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <section id="form-container" class="container form" style="margin:0">
    	<fieldset>
        	<legend>НАЧАЛНА ДЕСТИНАЦИЯ</legend>
            
            <span class="row size1 align-middle">
                <label>От къде искате да тръгнете?</label>
                <span><asp:Literal ID="FromLocationLiteral" runat="server"></asp:Literal></span>
            </span>
        </fieldset>
        
        <fieldset>
        	<legend>КРАЙНА ДЕСТИНАЦИЯ</legend>            
            <span class="row size1 align-middle">
                <label>До къде отивате?</label>
                <span><asp:Literal ID="ToLocationLiteral" runat="server"></asp:Literal></span>
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
                            <span><%=Item.StartFelxBefore %></span>                            
                        </span>
                        <span class="select">
                            <span><%=Item.StartFelxAfter %></span>
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
                            <span><%=Item.EndFelxBefore %></span>                            
                        </span>
                        <span class="select">
                            <span><%=Item.EndFelxAfter %></span>                            
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
        <fieldset>
        	<legend>брой на пътуващите</legend>
            
            <span class="row radio-icon people">
            	<label data-show="single">
                    <asp:RadioButton ID="AloneRadio" runat="server" GroupName="TravelersGroup" Checked="true" />
                    <span><img src="/images/icons/form/single.png" alt="" /></span>
                    <b>Самостоятелно</b>
                </label>
                <label data-show="single">
                	<asp:RadioButton ID="CoupleRadio" runat="server" GroupName="TravelersGroup" />
                    <span><img src="/images/icons/form/couple.png" alt="" /></span>
                    <b>Двойка</b>
                </label>
                <label data-show="family">
                	<asp:RadioButton ID="FamilyRadio" runat="server" GroupName="TravelersGroup" />
                    <span><img src="/images/icons/form/family.png" alt="" /></span>
                    <b>Семейство</b>
                </label>
                <label data-show="family">
                	<asp:RadioButton ID="PeopleGroupRadio" runat="server" GroupName="TravelersGroup" />
                    <span><img src="/images/icons/form/group.png" alt="" /></span>
                    <b>Група</b>
                </label>
            </span>
        </fieldset>
                
        <div class="sl-toggle">
            <div class="align-middle">
                <asp:PlaceHolder ID="AdultCountPlaceHolder" runat="server">
                <span>
                    <span class="select">
                        <span><%=Item.AdultCount %></span>                         
                    </span>
                    <label>Възрастни</label>
                </span>
                </asp:PlaceHolder>
                <asp:PlaceHolder ID="InvanvtCountPlaceHolder" runat="server">
                <span>
                    <span class="select">
                        <span><%=Item.ChildrenCount %></span> 
                    </span>
                    <label>Деца до 12г</label>
                </span>
                </asp:PlaceHolder>
                <asp:PlaceHolder ID="LuggageCountPlaceHolder" runat="server">
                <span>
                    <span class="select">
                        <span><%=Item.LuggageCount %></span>    
                    </span>
                    <label><img src="/images/icons/form/bags.png" /></label>
                </span>
                </asp:PlaceHolder>
                <asp:PlaceHolder ID="StudentsCountPlaceHolder" runat="server">
                <span>
                    <span class="select">
                        <span><%=Item.StudentCount %></span>
                    </span>
                    <label>Студенти</label>
                </span>
                </asp:PlaceHolder>
                <asp:PlaceHolder ID="ChildrenCountPlaceHolder" runat="server">
                <span>
                    <span class="select">
                        <span><%=Item.InvantCount %></span>   
                    </span>
                    <label>Бебета до 2г</label>
                </span>
                </asp:PlaceHolder>
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
                <asp:TextBox ID="TransportPriceRefererTextBox" Enabled="false" runat="server" MaxLength="100"></asp:TextBox>                
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
            <asp:PlaceHolder ID="RefererWebsitePlaceHolder" runat="server">
            <span class="row size1 align-middle">
                <label>От къде е получена цената?</label>
                <asp:TextBox ID="RefererWebsiteTextBox" Enabled="false" runat="server" MaxLength="100"></asp:TextBox>                
            </span>            
            </asp:PlaceHolder>
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
                <asp:TextBox ID="CarRentCompanyTextBox" Enabled="false" runat="server" ClientIDMode="Static" MaxLength="100"></asp:TextBox>                
            </span>
        </fieldset>     
        
        <fieldset>
        	<legend>БЮДЖЕТ</legend>
            
            <span class="row col2">         
            	<span>
                    <label>Стойност на получената оферта</label>
                    <span class="price">
                        <asp:TextBox ID="MaxPriceTextBox" runat="server" Enabled="false" ClientIDMode="Static"></asp:TextBox>
                        <span class="select">
                            <span><%=Item.Currency%></span>                            
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
        <asp:PlaceHolder ID="UserPersonalInfoPlaceHolder" runat="server">
        <fieldset>
        	<legend>данни за връзка</legend>
            
            <span class="row col2 align-middle">
            	<span>
                	<label>Име</label>
                    <asp:TextBox ID="FnameTextBox" runat="server" MaxLength="20" ClientIDMode="Static" Enabled="false"></asp:TextBox>
                </span>          	
                <span>
                	<label>Фамилия</label>
                    <asp:TextBox ID="LnameTextBox" runat="server" MaxLength="20" ClientIDMode="Static" Enabled="false"></asp:TextBox>
                </span>
            </span>
            
            <span class="row col2 align-middle">
            	<span>
                	<label>Ел.поща</label>
                    <asp:TextBox ID="EmailTextBox" runat="server" MaxLength="20" ClientIDMode="Static" Enabled="false"></asp:TextBox>
                </span>          	
                <span>
                    <label>Националност</label>
                    <span class="select">
                        <span><%=Item.Nationality %></span>                        
                    </span>
                </span>
            </span>
        </fieldset>
        </asp:PlaceHolder>
        <fieldset>
        	<legend>ВРЕМЕ ЗА ОТГОВОР</legend>
            
            <span class="row size2 align-middle">
                <label>Колкото повече време ни предоставите за отговор, толкова по-добра оферта ще ви предоставим.</label>
                <span class="select">
                    <span><%=Item.TimeToResearch %></span>                    
                </span>
            </span>
        </fieldset>
        
        
        <fieldset>
        	<legend>ДОПЪЛНИТЕЛНА ИНФОРМАЦИЯ</legend>
            
            <p>Моля да ни предоставите повече информация за вашето пътуване - какво искате да правите? Искате да посетите определени места? Искате или не искате да използвате дадена авиокомпания? Въобще всичко, което може да ни помогне да направим по-доброто предложение</p>            
            <span class="row">
                <asp:TextBox ID="AddInfoTextBox" runat="server" ClientIDMode="Static" TextMode="MultiLine" Rows="5" placeholder="Please tell us anything extra you would like to add.." Enabled="false"></asp:TextBox>            	
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
    </section>
        <script>
            $(function () {
                $("input[type=checkbox]").attr("disabled", "disabled");
                $("input[type=radio]").attr("disabled", "disabled");

                $("#from").datepicker({
                    dateFormat: 'M d, yy',
                    disabled: true,
                    onSelect: function (dateText) {
                        $("#HFDateFrom").val(dateText);
                    }
                });

                $("#to").datepicker({
                    dateFormat: 'M d, yy',
                    disabled: true,
                    onSelect: function (dateText) {
                        $("#HFDateTo").val(dateText);
                    }
                });

                

                $("#from").datepicker("setDate", $("#HFDateFrom").val());
                $("#to").datepicker("setDate", $("#HFDateTo").val());

                if ($("#IsOneWayRadio").is(":checked")) {
                    InitOneWay();
                }
            });

            function InitOneWay() {
                $("#TwoWayLi #to").datepicker("option", "disabled", true);
                $("#TwoWayLi select").attr("disabled", "disabled");
                $("#TwoWayLi #to").addClass("disabled");
                $("#TwoWayLi .row.col2").addClass("disabled");
            }
    </script>
    </form>
</body>
</html>
