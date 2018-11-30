package com.devesa.quartercontrol;

import android.os.AsyncTask;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.webkit.WebSettings;
import android.webkit.WebView;
import android.widget.ProgressBar;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {

    protected WebView appContent;
    protected ProgressBar progressBar;
    String url = "http://10.1.100.26:8094/";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        appContent = (WebView) findViewById(R.id.main_webView);
        progressBar = (ProgressBar) findViewById(R.id.progressBar);

    }

    protected class LoadDataTask extends AsyncTask<String, Integerer, String>{
        @Override
        protected void onPreExecute() {
            progressBar.setVisibility(View.VISIBLE);
            progressBar.setMax(100);
            progressBar.setProgress(0);
        }

        @Override
        protected void onPostExecute(String s) {
            progressBar.setVisibility(View.INVISIBLE);
        }

        @Override
        protected void onProgressUpdate(integer... values) {
            super.onProgressUpdate(values);
        }

        @Override
        protected String doInBackground(String... strings) {
            WebSettings webSettings = appContent.getSettings();
            webSettings.setJavaScriptEnabled(true);
            appContent.loadUrl(strings[0]);

            return null;
        }
    }
}
