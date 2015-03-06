<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="IvanovWebsite.Default" %>
<%@ Import Namespace="Core.Utilities" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="/js/jquery.parallax-1.1.3.js"></script>
<script src="/js/js.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<section class="about tabs">
    <nav>
        <ul>
            <li>
                <a href="#" data-tab-nav="tab1" class="active">КОЙ СМЕ НИЕ?</a>
            </li>
            <li>
                <a href="#" data-tab-nav="tab2">КАКВО ПРАВИМ НАЙ-ДОБРЕ?</a>
            </li>
            <li>
                <a href="#" data-tab-nav="tab3">КАК?</a>
            </li>
            <li>
                <a href="#" data-tab-nav="tab4">ЗАЩО С НАС?</a>
            </li>
        </ul>
    </nav>
        
    <div class="cnt">
        <div class="tab show" data-tab-content="tab1">
            <ul>
                <li>
                    <span class="icon">
                        <img src="/images/icons/about/who_1.png" alt="" />
                    </span>
                    <p>
                        Ние сме истински Ентусиасти  - за нас е предизвикателство да открием най-добрата оферта, защото обичаме да пътуваме и го правим без излишни разходи!
                    </p>
                </li>
                <li>
                    <span class="icon">
                        <img src="/images/icons/about/who_2.png" alt="" />
                    </span>
                    <p>
                        Ние сме Пътешественици - за нас няма недостъпни места. 
Просто е въпрос на време да ги посетим.
                    </p>
                </li>
                <li>
                    <span class="icon">
                        <img src="/images/icons/about/who_3.png" alt="" />
                    </span>
                    <p>
                        Най-важното, ние сме Приятели - и сме готови да споделим нашата емоция и опит с ВАС.
                    </p>
                </li>
            </ul>
        </div>
        <div class="tab" data-tab-content="tab2">
            <ul>
                <li>
                    <span class="icon">
                        <img src="/images/icons/about/what_1.png" alt="" />
                    </span>
                    <p>
                        Търсим и намираме най-добрите оферти за самолетни билети, хотел, кола под наем или с две думи, всичко за вашата незабравима ваканция.
                    </p>
                </li>
                <li>
                    <span class="icon">
                        <img src="/images/icons/about/what_2.png" alt="" />
                    </span>
                    <p>
                        Изготвяме индивидуално предложение съобразено с вашите предпочитания - "Made to measure" 
                    </p>
                </li>
                <li>
                    <span class="icon">
                        <img src="/images/icons/about/what_3.png" alt="" />
                    </span>
                    <p>
                        Помагаме ви да спестите! 
                    </p>
                </li>
            </ul>
        </div>
        <div class="tab" data-tab-content="tab3">
            <ul>
                <li>
                    <span class="icon">
                        <img src="/images/icons/about/how_1.png" alt="" />
                    </span>
                    <p>
                        Опишете ни вашето пътуване
                    </p>
                </li>
                <li>
                    <span class="icon">
                        <img src="/images/icons/about/how_2.png" alt="" />
                    </span>
                    <p>
                        Нашите травел експерти ще потърсят и ще ви предоставят най-добрата оферта
                    </p>
                </li>
                <li>
                    <span class="icon">
                        <img src="/images/icons/about/how_3.png" alt="" />
                    </span>
                    <p>
                        Пътувате за възможно най-добрата цена, а със спестените пари може да ни подарите сувенир
                    </p>
                </li>
            </ul>
        </div>
        <div class="tab" data-tab-content="tab4">
            <ul>
                <li>
                    <span class="icon">
                        <img src="/images/icons/about/why_1.png" alt="" />
                    </span>
                    <p>
                        Защото сме професионалисти в търсенето на оферти
                    </p>
                </li>
                <li>
                    <span class="icon">
                        <img src="/images/icons/about/why_2.png" alt="" />
                    </span>
                    <p>
                        Защото ще ви спестим време и средства
                    </p>
                </li>
                <li>
                    <span class="icon">
                        <img src="/images/icons/about/why_3.png" alt="" />
                    </span>
                    <p>
                        Защото не сме туристическа агенция и не търсим най-изгодното ЗА НАС предложение
                    </p>
                </li>
            </ul>
        </div>
    </div>
        
</section>
    
    
<section class="container">
    <h3>Последни Оферти</h3>
    <ul class="items col3">
        <asp:Repeater ID="OffersRepeater" runat="server" ViewStateMode="Disabled" ItemType="Core.LastOffer">
            <ItemTemplate>
                <li>
                    <a href="#">
                        <span class="img">
                            <img src="<%#AppSettings.UploadFileHttpPath+Item.Picture %>" alt="picture" />
                            <span><b>Прочети още</b></span>
                        </span>
                        <span class="text">
                            <strong><%# Item.Caption %></strong>
                            <span><%#Item.Location %></span>
                            <i class="users"><%# Item.UsersCount %></i>
                        </span>
                    </a>
                </li>
            </ItemTemplate>
        </asp:Repeater>        
    </ul>
</section>
    
<section class="container">
    <ul class="testimonials col3">        
        <li>
            <article>
                <figure>
                    <img src="/images/0/user.jpg" alt="" />
                </figure>
                <p>
                    "Tom was amazing. This was the first time I used Flightfox. Asiana Business Class New York to Asia for a little more than double Coach."
                </p>
                <span>John Doe</span>
            </article>
        </li>
        <li>
            <article>
                <figure>
                    <img src="/images/0/user.jpg" alt="" />
                </figure>
                <p>
                    "Tom was amazing. This was the first time I used Flightfox. Asiana Business Class New York to Asia for a little more than double Coach."
                </p>
                <span>John Doe</span>
            </article>
        </li>
        <li>
            <article>
                <figure>
                    <img src="/images/0/user.jpg" alt="" />
                </figure>
                <p>
                    "Tom was amazing. This was the first time I used Flightfox. Asiana Business Class New York to Asia for a little more than double Coach."
                </p>
                <span>John Doe</span>
            </article>
        </li>
    </ul>
</section>
    
<section class="container">
    <h3>Последни Дестинации</h3>
    <ul class="items col3">
        <asp:Repeater ID="LastDestinationsRepeater" runat="server" ViewStateMode="Disabled" ItemType="Core.Destination">
            <ItemTemplate>
            <li>
                <a href="/map/<%#Item.ID %>/">
                    <span class="img">
                        <img src="<%#AppSettings.UploadFileHttpPath+Item.Picture %>" alt="picture" />
                        <span><b>Прочети още</b></span>
                    </span>
                    <span class="text">
                        <strong><%# Item.Caption %></strong>                        
                    </span>
                </a>
            </li>
            </ItemTemplate>
        </asp:Repeater>       
    </ul>
</section>
    
<section class="container">
    <h3>Последни Статии</h3>
    <ul class="items col3">
        <li>
            <a href="#">
                <span class="img">
                    <img src="/images/0/img1.jpg" alt="" />
                    <span><b>Прочети още</b></span>
                </span>
                <span class="text">
                    <strong>Най-добрите дестинации за 2014</strong>
                    <span>30.01.2015г.</span>
                    <i class="comments">133</i>
                </span>
            </a>
        </li>
        <li>
            <a href="#">
                <span class="img">
                    <img src="/images/0/img2.jpg" alt="" />
                    <span><b>Прочети още</b></span>
                </span>
                <span class="text">
                    <strong>Луксозни хотели в Париж</strong>
                    <span>30.01.2015г.</span>
                    <i class="comments">133</i>
                </span>
            </a>
        </li>
        <li>
            <a href="#">
                <span class="img">
                    <img src="/images/0/img3.jpg" alt="" />
                    <span><b>Прочети още</b></span>
                </span>
                <span class="text">
                    <strong>Най-слънчевите курорти</strong>
                    <span>30.01.2015г.</span>
                    <i class="comments">133</i>
                </span>
            </a>
        </li>
    </ul>
</section>
    
</asp:Content>
