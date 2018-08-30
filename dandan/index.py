#! F:\Library\venv\Scripts\python.exe
# -*- coding:utf-8 -*-

#from werkzeug.serving import run_simple
#run_simple('localhost', 8080, app, use_reloader=True)

from wsgiref.handlers import CGIHandler
from app import app
CGIHandler().run(app)
