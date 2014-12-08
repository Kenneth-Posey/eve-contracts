
import webapp2
from google.appengine.ext import db, webapp
from google.appengine.ext.webapp.template import render
import locale, os, logging, datetime

class BaseHandler(webapp2.RequestHandler):
    REDIRECT = False
    REQUIRE_AUTH_POST = True
    REQUIRE_AUTH_GET = True
    
    def GetContext(self):
        return {}
    def PostContext(self):
        return {}
    def GetLocation(self):
        return self.LOCATION
    
    def GetUser(self):
        return users.get_current_user()
    
    def IsUserAdmin(self):
        return users.is_current_user_admin()
        
    def GetRedirect(self):
        return self.REDIRECT
    
    def get(self):
        return 
    
    def post(self):
        return
    