package org.application.security;

import java.util.Collection;
import java.util.List;

import org.application.entities.User;
import org.springframework.security.core.GrantedAuthority;
import org.springframework.security.core.authority.AuthorityUtils;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.util.StringUtils;

public class CustomUserDetails extends User implements UserDetails { 

	private static final long serialVersionUID = 1L;
	private List<String> userRoles;

	public CustomUserDetails(User user, List<String> userRoles){
		super(user.getId(), user.getUsername(), user.getEmail(), user.getPassword(), user.getTicket());
		this.userRoles = userRoles;
	}

	@Override
	public Collection<? extends GrantedAuthority> getAuthorities() {
		String roles=StringUtils.collectionToCommaDelimitedString(userRoles);
		return AuthorityUtils.commaSeparatedStringToAuthorityList(roles);
	}

	@Override
	public boolean isAccountNonExpired() {
		return true;
	}

	@Override
	public boolean isAccountNonLocked() {
		return true;
	}

	@Override
	public boolean isCredentialsNonExpired() {
		return true;
	}

	@Override
	public boolean isEnabled() {
		return true;
	}

	@Override
	public String getUsername() {
		return super.getUsername();
	}
}