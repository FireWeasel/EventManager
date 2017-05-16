var formModal = $('.cd-user-modal'),
		formLogin = formModal.find('#cd-login'),
		formSignup = formModal.find('#cd-signup'),
		formForgotPassword = formModal.find('#cd-reset-password'),
		formModalTab = $('.cd-switcher'),
		tabLogin = formModalTab.children('li').eq(0).children('a'),
		tabSignup = formModalTab.children('li').eq(1).children('a'),
		mainNav = $('.sidebar-nav');

function login_selected() {
	mainNav.children('ul').removeClass('is-visible');
	formModal.addClass('is-visible');
	formLogin.addClass('is-selected');
	formSignup.removeClass('is-selected');
	formForgotPassword.removeClass('is-selected');
	tabLogin.addClass('selected');
	tabSignup.removeClass('selected');
}

function signup_selected() {
	mainNav.children('ul').removeClass('is-visible');
	formModal.addClass('is-visible');
	formLogin.removeClass('is-selected');
	formSignup.addClass('is-selected');
	formForgotPassword.removeClass('is-selected');
	tabLogin.removeClass('selected');
	tabSignup.addClass('selected');
}

$(document).ready(function() {
  "use strict";

	

	mainNav.on('click', function(event){
		$(event.target).is(mainNav) && mainNav.children('ul').toggleClass('is-visible');
	});

	mainNav.on('click', '.cd-signup', signup_selected);
	mainNav.on('click', '.cd-signin', login_selected);

	formModal.on('click', function(event){
		if( $(event.target).is(formModal) || $(event.target).is('.cd-close-form') ) {
			formModal.removeClass('is-visible');
		}	
	});

	$(document).keyup(function(event){
    	if(event.which=='27'){
    		formModal.removeClass('is-visible');
	    }
    });

	formModalTab.on('click', function(event) {
		event.preventDefault();
		( $(event.target).is( tabLogin ) ) ? login_selected() : signup_selected();
	});
});